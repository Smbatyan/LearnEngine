using LearnEngine.Application.Exceptions;
using System.Net;

namespace LearnEngine.Application.Helpers
{
    public class HttpExceptionHelper
    {
        public void ThrowException(HttpStatusCode statusCode, string message, Exception ex = null)
        {
            throw statusCode switch
            {
                HttpStatusCode.BadRequest => new BadRequestException(message),
                HttpStatusCode.Unauthorized => new UnauthorizedException(message),
                HttpStatusCode.Forbidden => new AuthenticationFailException(message),
                HttpStatusCode.NotFound => new ResourceNotFoundException(message),
                HttpStatusCode.Conflict => new ConflictException(message),
                _ => ex,
            };
        }
    }
}
