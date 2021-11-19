namespace LearnEngine.Application.Exceptions
{
    public class AuthenticationFailException : Exception, IHttpResponseException
    {
        public int StatusCode { get; set; } = 403;
        public bool NeedsLog { get; set; }
        string IHttpResponseException.Message { get; set; }

        object IHttpResponseException.Data { get; set; }

        public AuthenticationFailException(string message = "forbidden") : base(message)
        {
            ((IHttpResponseException)this).Message = message;
        }

        public AuthenticationFailException(object data, string message = "forbidden") : base(message)
        {
            ((IHttpResponseException)this).Data = data;
            ((IHttpResponseException)this).Message = message;
        }
    }
}
