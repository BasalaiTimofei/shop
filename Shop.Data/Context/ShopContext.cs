using System;
using Shop.Data.Models;

namespace Shop.Data.Context
{
    using System.Data.Entity;

    public class ShopContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        static ShopContext()
        {
            Database.SetInitializer(new StoreDbInitializer());
        }
        public ShopContext()
            : base("name=ShopContext")
        {
        }
    }
    
    public class StoreDbInitializer : DropCreateDatabaseIfModelChanges<ShopContext>
    {
        protected override void Seed(ShopContext context)
        {
            context.Products.Add(new Product { Id = Guid.NewGuid().ToString(), Name = "Product One", Price = 1m });
            context.Products.Add(new Product { Id = Guid.NewGuid().ToString(), Name = "Product Two", Price = 2m });
            context.Products.Add(new Product { Id = Guid.NewGuid().ToString(), Name = "Product Three", Price = 3m });
            context.Products.Add(new Product { Id = Guid.NewGuid().ToString(), Name = "Product Four", Price = 4m });
            context.Products.Add(new Product { Id = Guid.NewGuid().ToString(), Name = "Product Five", Price = 5m });
            context.SaveChanges();
        }
    }
}