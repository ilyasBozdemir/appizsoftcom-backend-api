
using AppizsoftApp.Application.Interfaces;
using AppizsoftApp.Application.Interfaces.Services.Configurations;
using AppizsoftApp.Infrastructure.Services.Configurations;
using Microsoft.Extensions.DependencyInjection;

namespace AppizsoftApp.Application
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IApplicationService, ApplicationService>();
        }
    }
}
 