using DataAccessLayer.Commons.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace PresentationLayer.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception;
            var statusCode = HttpStatusCode.InternalServerError;
            string message = "An unexpected error occurred.";

            if (exception is ValidationFailureException validationEx)
            {
                statusCode = HttpStatusCode.UnprocessableEntity;
                context.HttpContext.Items["ErrorList"] = validationEx.Errors;
                message = "Validation failed.";
            }
            else if (exception is DataNotFoundException)
            {
                statusCode = HttpStatusCode.NotFound;
                message = exception.Message;
            }
            else if (exception is DataConflictException)
            {
                statusCode = HttpStatusCode.Conflict;
                message = exception.Message;
            }
            else if (exception is InvalidDataException)
            {
                statusCode = HttpStatusCode.BadRequest;
                message = exception.Message;
            }

            context.HttpContext.Response.StatusCode = (int)statusCode;
            context.Result = new PartialViewResult
            {
                ViewName = "_ErrorModal",
                ViewData = new Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary(
                    new Microsoft.AspNetCore.Mvc.ModelBinding.EmptyModelMetadataProvider(),
                    context.ModelState)
                {
                    { "ErrorMessage", message }
                }
            };

            context.ExceptionHandled = true;
        }
    }
}
