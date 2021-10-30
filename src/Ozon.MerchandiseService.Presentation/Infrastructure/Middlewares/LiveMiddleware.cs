using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Ozon.MerchandiseService.Presentation.Infrastructure.Middlewares
{
    public class LiveMiddleware
    {
        private readonly RequestDelegate _next;

        public LiveMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        
        public async Task InvokeAsync(HttpContext context)
        {
            context.Response.StatusCode = 200;
            await context.Response.WriteAsync("200 Ok");
        }
    }
}