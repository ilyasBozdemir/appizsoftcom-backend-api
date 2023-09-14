using AppizsoftApp.Application.Features.Users.Queries;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace AppizsoftApp.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationRegistration(this IServiceCollection services)
        {
            // `AddScoped`, her HTTP isteği için yeni bir hizmet örneği oluşturur ve bu isteğin ömrü boyunca aynı örneği kullanır.
            //senden IRequestHandler<ExistUserQuery, bool> istersem bana ExistUserQueryHandler ver
            services.AddScoped<IRequestHandler<ExistUserQuery, bool>, ExistUserQueryHandler>();
        
           
        }
    }
}
