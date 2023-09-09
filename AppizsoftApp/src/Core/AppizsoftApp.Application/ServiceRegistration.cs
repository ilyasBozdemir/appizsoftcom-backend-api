using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MediatR;

namespace AppizsoftApp.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationRegistration(this IServiceCollection services)
        {
            var assm = Assembly.GetExecutingAssembly();
           
            //services.AddMediatR(assm);
        }
    }
}
