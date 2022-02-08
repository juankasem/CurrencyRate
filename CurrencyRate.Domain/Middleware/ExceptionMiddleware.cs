using CurrencyRate.Domain.Exceptions;
using CurrencyRate.Domain.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace CurrencyRate.Domain.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        private ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (DomainException domainException)
            {
                await HandleDomainExceptionAsync(httpContext, domainException);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(httpContext, exception);
            }
        }

        private Task HandleDomainExceptionAsync(HttpContext httpContext, DomainException ex)
        {
            httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            httpContext.Response.ContentType = "application/json";

            var result = new ErrorModel(ex.Message);

            string json = JsonSerializer.Serialize(result);

            return httpContext.Response
                .WriteAsync(json);
        }

        private Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
        {
            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            httpContext.Response.ContentType = "application/json";

            var result = new ErrorModel("something went wrong");

            string json = JsonSerializer.Serialize(result);

            return httpContext.Response
                .WriteAsync(json);
        }
    }
}
