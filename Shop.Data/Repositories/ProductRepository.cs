using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Shop.Data.Context;
using Shop.Data.Interfaces;
using Shop.Data.Models;

namespace Shop.Data.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        private readonly ShopContext _shopContext;
        public ProductRepository(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }

        public IEnumerable<Product> GetAll()
        {
            return _shopContext.Products;
        }

        public IEnumerable<Product> Find(Predicate<Product> predicate)
        {
            var condition = new Func<Product, bool>(predicate);
            return _shopContext.Products.Where(condition);
        }

        public Product Get(string id)
        {
            return _shopContext.Products.First(
                f => string.Equals(f.Id, id, StringComparison.InvariantCultureIgnoreCase));
        }

        public void Create(Product item)
        {
            item.Id = Guid.NewGuid().ToString();
            _shopContext.Products.Add(item);
        }

        public void Update(Product item)
        {
            _shopContext.Entry(item).State = EntityState.Modified;
        }

        public void Delete(string id)
        {
            var product =
                _shopContext.Products.First(f => 
                    string.Equals(f.Id, id, StringComparison.InvariantCultureIgnoreCase));
            if (product != null)
                _shopContext.Products.Remove(product);
        }
    }
}