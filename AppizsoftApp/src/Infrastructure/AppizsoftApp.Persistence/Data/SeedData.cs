using Microsoft.EntityFrameworkCore;
using System.Drawing.Printing;

namespace AppizsoftApp.Persistence.Data
{
    public static class SeedData
    {
        public static void Initialize<TContext>(TContext context)
            where TContext : DbContext
        {
            /*
            if (!context.Products.Any() && !context.Categories.Any())
            {
                var category1 = new Category { Name = "Kategori 1" };
                var category2 = new Category { Name = "Kategori 2" };

                var product1 = new Product { Name = "Ürün 1", Price = 10.99, Category = category1 };
                var product2 = new Product { Name = "Ürün 2", Price = 19.99, Category = category1 };
                var product3 = new Product { Name = "Ürün 3", Price = 15.99, Category = category2 };
                var product4 = new Product { Name = "Ürün 4", Price = 22.99, Category = category2 };

                context.Categories.AddRange(category1, category2);
                context.Products.AddRange(product1, product2, product3, product4);

                context.SaveChanges();
            }
            */

        }
    }


}
