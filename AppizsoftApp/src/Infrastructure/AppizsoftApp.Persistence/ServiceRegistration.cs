using AppizsoftApp.Persistence.Context;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using AppizsoftApp.Domain.Entities.Identity;
using System.Configuration;
using AppizsoftApp.Application.Constants;
using Microsoft.AspNetCore.Identity;
using AppizsoftApp.Application.Interfaces.Services;
using AppizsoftApp.Persistence.Services;

namespace AppizsoftApp.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceRegistration(this IServiceCollection services)
        {
            services.AddDbContext<AppizsoftAppDBContext>(options => options
            .UseSqlServer(DBConnectionString.GetConnectionString(DeveloperName.Ilyas, DBType.SQLServer)));
            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
            }).AddEntityFrameworkStores<AppizsoftAppDBContext>()
            .AddDefaultTokenProviders();

            // services.AddScoped<IAuthRepository, EfAuthRepository>();//EF Core kullanıyoruz.




            services.AddScoped<IAuthService, AuthService>(); // Örnek bir kayıt

        }
    }
}
