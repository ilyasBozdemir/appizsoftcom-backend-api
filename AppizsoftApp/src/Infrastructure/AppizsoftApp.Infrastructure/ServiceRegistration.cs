using AppizsoftApp.Application.Interfaces;
using AppizsoftApp.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AppizsoftApp.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureRegistration(this IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();
        }
    }
}
