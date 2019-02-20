using System.Data.Entity.ModelConfiguration;
using Shop.Data.Models;

namespace Shop.Data.Context
{
    public class ProductConfiguration : EntityTypeConfiguration<Product>
    {
        public ProductConfiguration()
        {
            HasKey(h => h.Id);

            Property(p => p.Name).IsRequired().HasMaxLength(100);
            Property(p => p.Price).IsRequired();
        }
    }
}