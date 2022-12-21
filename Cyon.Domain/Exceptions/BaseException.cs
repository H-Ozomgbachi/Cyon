using Cyon.Domain.Common;

namespace Cyon.Domain.Exceptions
{
    public class BaseException : Exception
    {
        public HttpStatusCode StatusCode { get; }

        public BaseException(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
        }

        public BaseException(HttpStatusCode statusCode, string message)
        : base(message)
        {
            StatusCode = statusCode;
        }
    }
}
