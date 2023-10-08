using AppizsoftApp.Application.Interfaces;
using AppizsoftApp.Application.Interfaces.Services;
using AppizsoftApp.Infrastructure.Services;
using AppizsoftApp.Security.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AppizsoftApp.LoggingAndMonitoring
{
    public static class ServiceRegistration
    {
        public static void AddSecurityRegistration(this IServiceCollection services)
        {
            services.AddScoped<ITokenHandler, JwtTokenHandler>();
            services.AddTransient<IPasswordService, PasswordService>();
        }
    }
}
