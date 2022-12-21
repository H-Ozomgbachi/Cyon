using Cyon.Domain.Common;
using Cyon.Domain.Exceptions;

namespace Cyon.Api.Middlewares
{
    public class ExceptionHandler
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandler> _logger;

        public ExceptionHandler(RequestDelegate next, ILogger<ExceptionHandler> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)GetStatusCode(exception);

            _logger.LogError("Error processing request", exception.ToString());

            var errorMessage = exception.InnerException?.Message ?? exception.Message;

            // TODO: Use Json converter
            var jsonMesage = $"{{\"message\": \"{errorMessage}\"}}";

            await context.Response.WriteAsync(jsonMesage);
        }

        public HttpStatusCode GetStatusCode(Exception exception)
        {
            if (exception is not BaseException internalException)
            {
                return HttpStatusCode.InternalServerError;
            }
            return internalException.StatusCode;
        }
    }
}
