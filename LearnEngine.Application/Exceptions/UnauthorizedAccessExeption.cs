namespace LearnEngine.Application.Exceptions
{
    public class UnauthorizedAccessException : System.Exception, IHttpResponseException
    {
        public int StatusCode { get; set; } = 401;
        public bool NeedsLog { get; set; }

        string? IHttpResponseException.Key { get; set; } = "unauthorized_access";

        public UnauthorizedAccessException() : base("unauthorized_access")
        {
        }

        public UnauthorizedAccessException(string key) : base(key ?? "unauthorized_access")
        {
            ((IHttpResponseException)this).Key = key;
        }

        public UnauthorizedAccessException(string key, System.Exception? innerException)
            : base(key ?? "unauthorized_access", innerException)
        {
        }
    }
}