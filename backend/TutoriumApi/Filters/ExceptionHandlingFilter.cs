using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using tutorium.Exceptions;

namespace tutorium.Filters
{
    public class ExceptionHandlingFilter : IAsyncExceptionFilter
    {
        public Task OnExceptionAsync(ExceptionContext context)
        {
            CustomException? exception = context.Exception as CustomException;

            if (exception is NotFoundException) context.Result = new NotFoundObjectResult(exception.MessageObject);
            if (exception is BadRequestException) context.Result = new BadRequestObjectResult(exception.MessageObject);
            if (exception is UnauthorizedException) context.Result = new UnauthorizedObjectResult(exception.MessageObject);

            return Task.CompletedTask;
        }
    }
}
