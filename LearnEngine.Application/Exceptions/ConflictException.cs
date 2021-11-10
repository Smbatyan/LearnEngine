namespace LearnEngine.Application.Exceptions
{
    public class ConflictException : Exception, IHttpResponseException
    {
        public int StatusCode { get; set; } = 409;
        public bool NeedsLog { get; set; }
        string IHttpResponseException.Message { get; set; }

        public ConflictException(string message) : base(message ?? "Conflict")
        {
            ((IHttpResponseException)this).Message = message;
        }

        public ConflictException(string message, Exception innerException)
            : base(message ?? "Conflict", innerException)
        {
            ((IHttpResponseException)this).Message = message;
        }
    }
}
