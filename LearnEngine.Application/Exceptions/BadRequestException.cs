namespace LearnEngine.Application.Exceptions
{
    public class BadRequestException: Exception, IHttpResponseException
    {
        public int StatusCode { get; set; } = 400;
        public bool NeedsLog { get; set; }
        string IHttpResponseException.Message { get; set; }
        object IHttpResponseException.Data { get; set; }

        public BadRequestException(string message = "bad_request") : base(message)
        {
            ((IHttpResponseException)this).Message = message;
        }

        public BadRequestException(object data, string message = "bad_request") : base(message)
        {
            ((IHttpResponseException)this).Data = data;
            ((IHttpResponseException)this).Message = message;
        }
    }
}