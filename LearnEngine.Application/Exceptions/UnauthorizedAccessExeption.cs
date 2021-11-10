namespace LearnEngine.Application.Exceptions
{
    public class UnauthorizedException : System.Exception, IHttpResponseException
    {
        public int StatusCode { get; set; } = 401;
        public bool NeedsLog { get; set; }

        string IHttpResponseException.Message { get; set; } = "unauthorized_access";

        public UnauthorizedException() : base("unauthorized_access")
        {
        }

        public UnauthorizedException(string message) : base(message ?? "unauthorized_access")
        {
            ((IHttpResponseException)this).Message = Message;
        }

        public UnauthorizedException(string key, Exception innerException)
            : base(key ?? "unauthorized_access", innerException)
        {
        }
    }
}