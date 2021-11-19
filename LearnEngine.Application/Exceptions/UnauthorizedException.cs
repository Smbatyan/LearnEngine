using System.Text.Json;

namespace LearnEngine.Application.Exceptions
{
    public class UnauthorizedException : Exception, IHttpResponseException
    {
        public int StatusCode { get; set; } = 401;
        public bool NeedsLog { get; set; }
        string IHttpResponseException.Message { get; set; } 

        object IHttpResponseException.Data { get; set; }

        public UnauthorizedException(string message = "unauthorized") : base(message)
        {
            ((IHttpResponseException)this).Message = message;
        }

        public UnauthorizedException(object data, string message = "unauthorized") : base(message)
        {
            ((IHttpResponseException)this).Data = data;
            ((IHttpResponseException)this).Message = message;
        }
    }
}