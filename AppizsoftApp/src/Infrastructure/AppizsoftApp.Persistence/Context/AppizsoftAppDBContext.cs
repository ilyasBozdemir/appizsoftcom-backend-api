using AppizsoftApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppizsoftApp.Persistence.Context
{
    public class AppizsoftAppDBContext : DbContext
    {
        public AppizsoftAppDBContext(DbContextOptions<AppizsoftAppDBContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        // Diğer DbSet özellikleri (örneğin, diğer varlıklar) eklenebilir

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            
        }
    }
}
