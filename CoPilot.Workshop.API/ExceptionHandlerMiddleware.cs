using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Diagnostics;
using System.Text.Json;
using CoPilot.Workshop.Framework;

namespace CoPilot.Workshop.API
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            var (statusCode, response) = exception switch
            {
                ValidationException validationException => (
                    StatusCodes.Status400BadRequest,
                    new
                    {
                        Title = "Validation Errors",
                        validationException.Errors
                    }
                ),
                _ => (
                    StatusCodes.Status500InternalServerError,
                    (object)new
                    {
                        Title = "An unexpected error occurred.",
                        Detail = exception.Message
                    }
                )
            };

            context.Response.StatusCode = statusCode;
            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}
