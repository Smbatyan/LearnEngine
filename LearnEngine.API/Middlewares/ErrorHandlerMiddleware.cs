using LearnEngine.Application.Exceptions;
using LearnEngine.Application.ResponseModels.ErrorModels;
using System.Net;
using System.Net.Mime;
using System.Text.Json;

namespace LearnEngine.API.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private const string _controller = "controller";
        private const string _correlationId = "SL-Correlation-Id";
        private const string _errorMessage = "Something went wrong";

        private readonly RequestDelegate _next;
        private readonly ILoggerFactory _logger;

        public ErrorHandlerMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext) // TODO
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                string body = default;
                string controllerName = httpContext.Request.RouteValues[_controller]?.ToString()?.ToLower();
                string correlationId = httpContext.Request.Headers[_correlationId].ToString();
                httpContext.Response.ContentType = MediaTypeNames.Application.Json;
                //IdentityUserInfo identity = JWTUserExtractor.GetUserInfo(httpContext.User);

                //ex.Data.AddResponseDefaultData(identity, correlationId); //TODO

                if (ex is IHttpResponseException httpEx)
                {
                    ErrorResponse errorResponse = httpEx.GenerateResponse();
                    body = JsonSerializer.Serialize(errorResponse);

                    httpContext.Response.StatusCode = httpEx.StatusCode;
                }
                else
                {
                    body = JsonSerializer.Serialize(_errorMessage);
                    httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    _logger.CreateLogger(controllerName)?.LogError(ex.Message, ex.InnerException?.Message, ex.Data.ToString());
                }

                await httpContext.Response.WriteAsync(body);
            }
        }
    }
}
