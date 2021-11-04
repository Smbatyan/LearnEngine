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
        string IHttpResponseException.Key { get; set; }

        public AuthenticationFailException(string key = null) : base(key ?? "forbidden")
        {
            ((IHttpResponseException)this).Key = key;
        }

        public AuthenticationFailException(string key, Exception innerException)
            : base(key, innerException)
        {
            ((IHttpResponseException)this).Key = key;
        }
    }
}
