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
            string? detail = null;
            switch (context.Exception)
            {
                case CustomException customException:
                    result = new BadRequestObjectResult(new ProblemDetails
                    {
                        Title = "Bad Request", Detail = customException.Message,
                    });
                    break;
                case ArgumentNullException argumentNullException:
                    result = new BadRequestObjectResult(new ProblemDetails
                    {
                        Type = Constans.BadRequestType,
                        Title = "Bad Request",
                        Status = (int)HttpStatusCode.BadRequest,
                        Detail = detail,
                    });
                    break;
                case InvalidOperationException invalidOperationException:
                    result = new BadRequestObjectResult(new ProblemDetails
                    {
                        Type = Constans.BadRequestType,
                        Title = "Bad Request",
                        Status = (int)HttpStatusCode.BadRequest,
                        Detail = "Invalid operation",
                    });
                    break;
                case HttpRequestException httpRequestException:
                    result = new ObjectResult(new ProblemDetails
                    {
                        Type = Constans.ServiceUnavailableType,
                        Title = "Service Unavailable",
                        Status = StatusCodes.Status503ServiceUnavailable,
                        Detail = "A network error occurred.",
                    });
                    break;
                default:
                    result = new ObjectResult(new ProblemDetails
                    {
                        Type = Constans.InternalServerErrorType,
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