using System.Runtime.Serialization;

namespace LearnEngine.Application.Exceptions
{
    public class ResourceNotFoundException : System.Exception, IHttpResponseException
    {
        public int StatusCode { get; set; } = 404;
        public bool NeedsLog { get; set; }
        string? IHttpResponseException.Key { get; set; }

        public ResourceNotFoundException(string key = "not_found") : base(key)
        {
            ((IHttpResponseException)this).Key = key;
        }

        public ResourceNotFoundException(Exception inner , string key = "not_found") : base(key, inner)
        {
            ((IHttpResponseException)this).Key = key;
        }

        protected ResourceNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            
        }

    }
}