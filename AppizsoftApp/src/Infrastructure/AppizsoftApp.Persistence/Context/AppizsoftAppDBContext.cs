using AppizsoftApp.Application.Constants;
using AppizsoftApp.Domain.Entities;
using AppizsoftApp.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AppizsoftApp.Persistence.Context
{
    public class AppizsoftAppDBContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public AppizsoftAppDBContext(DbContextOptions<AppizsoftAppDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // IEntityTypeConfiguration<> tipinde ki yapılandırma sınıflarını otomatik olarak uygula
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

    }
}
