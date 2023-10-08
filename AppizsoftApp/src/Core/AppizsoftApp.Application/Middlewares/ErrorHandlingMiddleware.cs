using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net;

namespace AppizsoftApp.Application.Middlewares
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
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
                // Hata türüne bağlı olarak uygun bir yanıt üretin
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";
                var errorResponse = new { message = "Internal Server Error", error = ex.Message };
                await context.Response.WriteAsync(JsonConvert.SerializeObject(errorResponse));
            }
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
             
            }
        }
    }

}
