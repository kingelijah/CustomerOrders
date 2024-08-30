using CustomerOrders.Application.Exceptions;
using System.Net;
using Newtonsoft.Json;

namespace CustomerOrders.API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (CustomException ex)
            {
                _logger.LogError(ex, "Custom exception occurred");
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = ex.StatusCode;
                var response = new { message = ex.Message };
                await context.Response.WriteAsync(JsonConvert.SerializeObject(response));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unhandled exception occurred");
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                var response = new { message = "An unexpected error occurred here." };
                await context.Response.WriteAsync(JsonConvert.SerializeObject(response));
            }
        }
    }
}
