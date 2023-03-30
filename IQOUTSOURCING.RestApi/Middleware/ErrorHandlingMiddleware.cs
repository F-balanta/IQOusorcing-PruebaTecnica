using IQOUTSOURCING.TransversalHelpers.ExceptionHelper;
using System.Diagnostics;
using System.Net;
using System.Text.Json;

namespace IQOUTSOURCING.RestApi.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex, _logger);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception ex, ILogger<ErrorHandlingMiddleware> logger)
        {
            string? message = null;

            switch (ex)
            {
                case RestException re:
                    logger.LogError(ex, "Error: ");
                    message = re.message;
                    context.Response.StatusCode = (int)re.code;
                    break;
                case Exception e:
                    StackTrace trace = new StackTrace(ex, true);



                    logger.LogError(ex, "Error en el servidor: ");
                    if (ex.InnerException != null)
                    {
                        message = string.IsNullOrEmpty(ex.InnerException.Message) ? "Error: " : ex.InnerException.Message;
                    }
                    else
                    {
                        message = string.IsNullOrEmpty(e.Message) ? "Error: " : e.Message;
                    }

                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            context.Response.ContentType = "application/json";

            if (message != null)
            {
                string? result = JsonSerializer.Serialize(new { message });
                await context.Response.WriteAsync(result);
            }
        }
    }
}
