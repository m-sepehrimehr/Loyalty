using Loyalty.Domain.Common.Exceptions;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Loyalty.EndPoints.Api.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;
        private readonly IConfiguration _configuration;
        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger, IConfiguration configuration)
        {
            this.next = next;
            _logger = logger;
            _configuration = configuration;
        }

        public async Task Invoke(HttpContext context)
        {
            context.Request.EnableBuffering();

            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var code = 500;
            context.Response.ContentType = "application/json";
            object result = null;
            switch (ex)
            {
                case BusinessException businessException:
                    code = 400;
                    result = new 
                    {
                        Error=businessException.Message
                    };
                    break;
                
               
            }

            context.Response.StatusCode = code;
            await context.Response.WriteAsJsonAsync(result);
            
        }
        
    }
}
