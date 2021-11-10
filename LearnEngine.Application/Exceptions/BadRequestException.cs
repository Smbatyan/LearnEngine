namespace LearnEngine.Application.Exceptions
{
    public class BadRequestException: Exception, IHttpResponseException
    {
        public int StatusCode { get; set; } = 400;
        public bool NeedsLog { get; set; }
        string IHttpResponseException.Message { get; set; }

        public BadRequestException(string message = "bad_request") : base(message)
        {
            ((IHttpResponseException)this).Message = message;
        }

        public BadRequestException(string message, Exception innerException)
            : base(message, innerException)
        {
            ((IHttpResponseException)this).Message = message;
        }
    }
}