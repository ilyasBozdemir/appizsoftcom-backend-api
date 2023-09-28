using AppizsoftApp.Application.Interfaces.Services;
using AppizsoftApp.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AppizsoftApp.LoggingAndMonitoring
{
    public static class ServiceRegistration
    {
        public static void AddEmailServiceRegistration(this IServiceCollection services)
        {
            services.AddScoped<IEmailService, SmtpEmailService>();
        }
    }
}
