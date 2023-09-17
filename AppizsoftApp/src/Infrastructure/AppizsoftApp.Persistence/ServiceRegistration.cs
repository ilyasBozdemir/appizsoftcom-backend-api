using AppizsoftApp.Persistence.Context;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using AppizsoftApp.Application.Interfaces.Repositories;
using AppizsoftApp.Persistence.Repositories.Entity_Framework;

namespace AppizsoftApp.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceRegistration(this IServiceCollection services)
        {
            services.AddDbContext<AppizsoftAppDBContext>(options =>
            {
                options.UseInMemoryDatabase("AppizsoftAppDBContext"); 
            });

            /*
            if (env.IsDevelopment())
            {
                services.AddDbContext<AppizsoftAppDBContext>(options =>
                {
                    options.UseSqlServer(Configuration.GetConnectionString("LocalConnection"));
                });
            }
            else
            {
                services.AddDbContext<AppizsoftAppDBContext>(options =>
                {
                    options.UseSqlServer(Configuration.GetConnectionString("ProductionConnection"));
                });
            }
            */


            services.AddScoped<IAuthRepository, EfAuthRepository>();//EF Core kullanıyoruz.

        }
    }
}
