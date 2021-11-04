using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LearnEngine.Application.Exceptions
{
    public class HttpExceptionHelper
    {
        public void ThrowException(HttpStatusCode statusCode, string message, Exception ex = null)
        {
            throw statusCode switch
            {
                HttpStatusCode.BadRequest => new BadRequestException(message),
                HttpStatusCode.Unauthorized => new UnauthorizedAccessException(message),
                HttpStatusCode.Forbidden => new AuthenticationFailException(message),
                HttpStatusCode.NotFound => new ResourceNotFoundException(message),
                HttpStatusCode.Conflict => new ConflictException(message),
                _ => ex,
            };
        }
    }
}
