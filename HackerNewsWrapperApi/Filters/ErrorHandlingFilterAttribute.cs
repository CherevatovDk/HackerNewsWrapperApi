using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace HackerNewsWrapperApi.Filters
{
    public class ErrorHandlingFilterAttribute : ExceptionFilterAttribute
    {
        private readonly ILogger<ErrorHandlingFilterAttribute> _logger;

        public ErrorHandlingFilterAttribute(ILogger<ErrorHandlingFilterAttribute> logger)
        {
            _logger = logger;
        }

        public override void OnException(ExceptionContext context)
        {
            IActionResult? result;
            switch (context.Exception)
            {
                case ArgumentNullException argumentNullException:
                    result = new BadRequestObjectResult(new ProblemDetails
                    {
                        Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
                        Title = "Bad Request",
                        Status = (int)HttpStatusCode.BadRequest,
                        Detail = "Invalid request parameters",
                    });
                    break;
                case InvalidOperationException invalidOperationException:
                    result = new BadRequestObjectResult(new ProblemDetails
                    {
                        Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
                        Title = "Bad Request",
                        Status = (int)HttpStatusCode.BadRequest,
                        Detail = "Invalid operation",
                    });
                    break;
                case HttpRequestException httpRequestException:
                    result = new ObjectResult(new ProblemDetails
                    {
                        Type = "https://tools.ietf.org/html/rfc7231#section-6.6.4",
                        Title = "Service Unavailable",
                        Status = StatusCodes.Status503ServiceUnavailable,
                        Detail = "A network error occurred.",
                    });
                    break;
                default:
                    result = new ObjectResult(new ProblemDetails
                    {
                        Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
                        Title = "An error occurred while processing your request.",
                        Status = (int)HttpStatusCode.InternalServerError,
                    });
                    break;
            }

            _logger.LogError(context.Exception, "An unhandled exception occurred: {ErrorMessage}",
                context.Exception.Message);
            context.Result = result;
            context.ExceptionHandled = true;
        }
    }
}