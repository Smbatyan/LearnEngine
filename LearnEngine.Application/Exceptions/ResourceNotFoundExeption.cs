namespace LearnEngine.Application.Exceptions
{
    public class ResourceNotFoundException : System.Exception, IHttpResponseException
    {
        public int StatusCode { get; set; } = 404;
        public bool NeedsLog { get; set; }
        string IHttpResponseException.Message { get; set; }

        object IHttpResponseException.Data { get; set; }

        public ResourceNotFoundException(string message = "not_found") : base(message)
        {
            ((IHttpResponseException)this).Message = message;
        }

        public ResourceNotFoundException(object data, string message = "not_found") : base(message)
        {
            ((IHttpResponseException)this).Data = data;
            ((IHttpResponseException)this).Message = message;
        }

    }
}