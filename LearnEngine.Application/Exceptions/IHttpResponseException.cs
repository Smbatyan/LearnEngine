using LearnEngine.Application.ResponseModels.ErrorModels;

namespace LearnEngine.Application.Exceptions
{
    public interface IHttpResponseException
    {
        int StatusCode { get; set; }
        bool NeedsLog { get; set; } // Will be used
        string Message { get; set; }

        public ErrorResponse GenerateResponse()
        {
            ErrorResponse errorResponse = new()
            {
                Message = this.Message
            }; // TODO...

            return errorResponse;
        }
    }
}