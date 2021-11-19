namespace LearnEngine.Application.Exceptions
{
    public class ConflictException : Exception, IHttpResponseException
    {
        public int StatusCode { get; set; } = 409;
        public bool NeedsLog { get; set; }
        string IHttpResponseException.Message { get; set; }
        object IHttpResponseException.Data { get; set; }

        public ConflictException(string message = "conflict") : base(message)
        {
            ((IHttpResponseException)this).Message = message;
        }

        public ConflictException(object data, string message = "conflict") : base(message)
        {
            ((IHttpResponseException)this).Data = data;
            ((IHttpResponseException)this).Message = message;
        }
    }
}
