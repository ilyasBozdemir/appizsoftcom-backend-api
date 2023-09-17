using AppizsoftApp.Application.Features.Auths.Commands;
using AppizsoftApp.Application.Features.Auths.Queries;
using AppizsoftApp.Application.Features.Auths.Results;
using AppizsoftApp.Application.Features.Users.Queries;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace AppizsoftApp.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationRegistration(this IServiceCollection services)
        {
            var assm = Assembly.GetExecutingAssembly();
            services.AddAutoMapper(assm);


            // `AddScoped`, her HTTP isteği için yeni bir hizmet örneği oluşturur ve bu isteğin ömrü boyunca aynı örneği kullanır.
            //senden IRequestHandler<ExistUserQuery, bool> istersem bana ExistUserQueryHandler ver
            services.AddScoped<IRequestHandler<ExistUserQuery, ExistUserResult>, ExistUserQueryHandler>();
            services.AddScoped<IRequestHandler<CreateUserCommand, CreateUserResult>, CreateUserCommandHandler>();
            services.AddScoped<IRequestHandler<LoginCommand, LoginResult>, LoginCommandHandler>();
            services.AddScoped<IRequestHandler<CheckSessionQuery, bool>, CheckSessionQueryHandler>();
        }
    }
}
