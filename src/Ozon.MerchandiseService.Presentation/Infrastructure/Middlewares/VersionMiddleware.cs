using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ozon.MerchandiseService.Presentation.Infrastructure.Middlewares
{
    public class VersionMiddleware
    {
        private readonly RequestDelegate _next;
        
        public VersionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        
        public async Task InvokeAsync(HttpContext context)
        {
            var version = Assembly.GetExecutingAssembly().GetName().Version.ToString() ?? "no version";
            var serviceName = Assembly.GetExecutingAssembly().GetName().Name;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsJsonAsync(new {version, serviceName});
        }
    }
}