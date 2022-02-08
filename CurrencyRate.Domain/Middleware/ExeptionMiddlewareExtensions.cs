

using Microsoft.AspNetCore.Builder;

namespace CurrencyRate.Domain.Middleware
{
  public static class ExeptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
