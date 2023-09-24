using AppizsoftApp.Application.Interfaces;
using AppizsoftApp.Application.Interfaces.Services;
using AppizsoftApp.Infrastructure.Services;
using AppizsoftApp.Infrastructure.Services.Common;
using Microsoft.Extensions.DependencyInjection;

namespace AppizsoftApp.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureRegistration(this IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IEmailService, SmtpEmailService>();
            services.AddTransient<IPasswordService, PasswordService>();
        }
    }
}
