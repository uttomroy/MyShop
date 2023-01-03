using Microsoft.AspNetCore.Http;
using System.Globalization;
using MyShop.Core.Services.TokenHandler;

namespace MyShop.Core.Middleware
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ITokenHandlerService _tokenHandlerService;

        public AuthenticationMiddleware(RequestDelegate next, ITokenHandlerService tokenHandlerService)
        {
            _next = next;
            _tokenHandlerService = tokenHandlerService;
        }

        public async Task InvokeAsync(HttpContext context)
        {

            string token = context.Request.Cookies["token"]?.ToString();
            if (string.IsNullOrEmpty(token))
            {
                Console.WriteLine("nice to meet y");
            }
            // Call the next delegate/middleware in the pipeline.
            await _next(context);
        }
    }
}
