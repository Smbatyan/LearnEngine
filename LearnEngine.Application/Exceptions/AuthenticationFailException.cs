using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEngine.Application.Exceptions
{
    public class AuthenticationFailException : Exception, IHttpResponseException
    {
        public int StatusCode { get; set; } = 403;
        public bool NeedsLog { get; set; }
        string IHttpResponseException.Message { get; set; }

        public AuthenticationFailException(string message = null) : base(message ?? "forbidden")
        {
            ((IHttpResponseException)this).Message = message;
        }

        public AuthenticationFailException(string message, Exception innerException)
            : base(message, innerException)
        {
            ((IHttpResponseException)this).Message = message;
        }
    }
}
