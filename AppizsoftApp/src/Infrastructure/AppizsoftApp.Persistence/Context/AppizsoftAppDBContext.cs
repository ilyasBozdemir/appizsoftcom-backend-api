using AppizsoftApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppizsoftApp.Persistence.Context
{
    public class AppizsoftAppDBContext : DbContext
    {
        public AppizsoftAppDBContext(DbContextOptions<AppizsoftAppDBContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<AuthToken> AuthTokens { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


        }
    }
}
