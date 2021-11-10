using System.Runtime.Serialization;

namespace LearnEngine.Application.Exceptions
{
    public class ResourceNotFoundException : System.Exception, IHttpResponseException
    {
        public int StatusCode { get; set; } = 404;
        public bool NeedsLog { get; set; }
        string IHttpResponseException.Message { get; set; }

        public ResourceNotFoundException(string message = null) : base(message ?? "not_found")
        {
            ((IHttpResponseException)this).Message = message;
        }

        public ResourceNotFoundException(Exception inner , string message = null) : base(message ?? "not_found", inner)
        {
            ((IHttpResponseException)this).Message = Message;
        }

        protected ResourceNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            
        }

    }
}