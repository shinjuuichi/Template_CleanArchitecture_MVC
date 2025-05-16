using DataAccessLayer.Commons.Exceptions;
using System.Net;
using System.Text.Json;

namespace PresentationLayer.Middlewares
{
    public class ExceptionHandlingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (ValidationFailureException ex)
            {
                await HandleExceptionAsync(context, HttpStatusCode.UnprocessableEntity, ex.Errors);
            }
            catch (DataNotFoundException ex)
            {
                await HandleExceptionAsync(context, HttpStatusCode.NotFound, ex.Message);
            }
            catch (DataConflictException ex)
            {
                await HandleExceptionAsync(context, HttpStatusCode.Conflict, ex.Message);
            }
            catch (InvalidDataException ex)
            {
                await HandleExceptionAsync(context, HttpStatusCode.BadRequest, ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                await HandleExceptionAsync(context, HttpStatusCode.InternalServerError, "Internal Server Error");
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, HttpStatusCode statusCode, dynamic message)
        {
            context.Response.StatusCode = (int)statusCode;
            context.Response.ContentType = "application/json";
            return context.Response.WriteAsync(JsonSerializer.Serialize(new { error = message }));
        }
    }
}
