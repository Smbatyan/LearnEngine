namespace LearnEngine.Application.Exceptions
{
    public class ConflictException : Exception, IHttpResponseException
    {
        public int StatusCode { get; set; } = 409;
        public bool NeedsLog { get; set; }
        string IHttpResponseException.Key { get; set; }

        public ConflictException(string key) : base(key ?? "Conflict")
        {
            ((IHttpResponseException)this).Key = key;
        }

        public ConflictException(string key, Exception innerException)
            : base(key ?? "Conflict", innerException)
        {
            ((IHttpResponseException)this).Key = key;
        }
    }
}
