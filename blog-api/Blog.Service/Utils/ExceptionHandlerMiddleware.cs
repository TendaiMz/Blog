using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Blog.Service.Utils
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ExceptionHandlerMiddleware
    {
        private readonly ILogger _logger;
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
        {
            _logger = logger;
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception exception)
            {

                await TryHandleExceptionAsync(httpContext, exception, _logger);
            }


        }

        private Task TryHandleExceptionAsync(HttpContext httpContext, Exception exception, ILogger logger)
        {
            logger.LogError($"{exception.Message}");
            var result = JsonConvert.SerializeObject(new { error = exception.Message });
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return httpContext.Response.WriteAsync(result);
        }
    }


}
