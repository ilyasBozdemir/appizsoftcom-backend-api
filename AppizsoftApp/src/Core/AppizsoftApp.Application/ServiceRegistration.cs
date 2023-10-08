
using AppizsoftApp.Application.Features.Commands.LoginUser;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace AppizsoftApp.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationRegistration(this IServiceCollection services)
        {

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            // `AddScoped`, her HTTP isteği için yeni bir hizmet örneği oluşturur ve bu isteğin ömrü boyunca aynı örneği kullanır.
          

            services.AddTransient<IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>, LoginUserCommandHandler>();
            services.AddHttpClient();
        }
    }
}
 