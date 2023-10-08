using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;


namespace AppizsoftApp.Application.Middlewares
{
    public class AuthorizationMiddleware: IMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthorizationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
         
            if (!IsUserAuthorized(context.User)) 
            {
                context.Response.StatusCode = 403; 
                await context.Response.WriteAsync("Erişim Reddedildi. Yetkiniz Yok.");
                return;
            }
            await _next(context);
        }

        public Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            throw new NotImplementedException();
        }

        private bool IsUserAuthorized(ClaimsPrincipal user)
        {
            return true;
           // return user.IsInRole("Admin");
        }
    }
}


