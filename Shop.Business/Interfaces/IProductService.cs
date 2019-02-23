using System.Collections.Generic;
using Shop.Business.Models;

namespace Shop.Business.Interfaces
{
    public interface IProductService
    {
        Product Get(string id);
        IEnumerable<Product> GetAll();
        void Add(Product product);
        void Dispose();
    }
}
