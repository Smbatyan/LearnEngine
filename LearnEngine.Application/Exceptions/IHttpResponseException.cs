using LearnEngine.Application.ResponseModels.ErrorModels;

namespace LearnEngine.Application.Exceptions
{
    public interface IHttpResponseException
    {
        int StatusCode { get; set; }
        bool NeedsLog { get; set; } // Will be used
        string Key { get; set; }

        public ErrorResponse GenerateResponse()
        {
            ErrorResponse errorResponse = new()
            {
                Key = this.Key 
            }; // TODO...

            return errorResponse;
        }
    }
}