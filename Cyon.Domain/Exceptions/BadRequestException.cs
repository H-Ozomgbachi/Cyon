using Cyon.Domain.Common;

namespace Cyon.Domain.Exceptions
{
    public class BadRequestException : BaseException
    {
        public BadRequestException() : base(HttpStatusCode.BadRequest)
        {
        }

        public BadRequestException(string message) : base(HttpStatusCode.BadRequest, message)
        {
        }
    }
}
