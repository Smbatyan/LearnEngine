namespace LearnEngine.Application.Exceptions
{
    public class BadRequestException: Exception, IHttpResponseException
    {
        public int StatusCode { get; set; } = 400;
        public bool NeedsLog { get; set; }
        string? IHttpResponseException.Key { get; set; }

        public BadRequestException(string key = "bad_request") : base(key)
        {
            ((IHttpResponseException)this).Key = key;
        }

        public BadRequestException(string key, Exception innerException)
            : base(key, innerException)
        {
            ((IHttpResponseException)this).Key = key;
        }
    }
}