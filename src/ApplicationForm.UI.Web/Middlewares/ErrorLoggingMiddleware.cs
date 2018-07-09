using Microsoft.AspNetCore.Http;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ApplicationForm.UI.Web.Middlewares
{
    public class ErrorLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
                Debug.WriteLine($"The following error happened: {ex.Message}");
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = StatusCodes.Status500InternalServerError;

            if (exception is ArgumentException || exception is ArgumentNullException)
                code = StatusCodes.Status400BadRequest;

            var result = exception.Message;
            context.Response.ContentType = "text/html";
            context.Response.StatusCode = code;

            await context.Response.WriteAsync(result);
        }
    }
}
