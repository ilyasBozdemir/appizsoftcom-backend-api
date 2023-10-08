using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using AppizsoftApp.Application.Constants;
using AppizsoftApp.Persistence.Context;

namespace AppizsoftApp.Persistence
{

    public class IDesignTimeAppizsoftAppDBContext : IDesignTimeDbContextFactory<AppizsoftAppDBContext>
    {
        public AppizsoftAppDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppizsoftAppDBContext>();
            optionsBuilder.UseSqlServer(DBConnectionString.GetConnectionString(DeveloperName.Ilyas, DBType.SQLServer));
            return new AppizsoftAppDBContext(optionsBuilder.Options);
        }
    }
}
