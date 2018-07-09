using ApplicationForm.UI.Web.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace ApplicationForm.UI.Web.Extensions
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseErrorLogging(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorLoggingMiddleware>();
        }
    }
}
