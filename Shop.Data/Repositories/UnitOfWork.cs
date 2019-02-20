using System;
using Shop.Data.Context;
using Shop.Data.Interfaces;
using Shop.Data.Models;

namespace Shop.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ShopContext _shopContext;
        private ProductRepository _productRepository;

        public UnitOfWork(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }

        public IRepository<Product> Products =>
            _productRepository ?? (_productRepository = new ProductRepository(_shopContext));

        public void Save()
        {
            _shopContext.SaveChanges();
        }
        private bool _disposed;

        public virtual void Dispose(bool disposing)
        {
            if (_disposed) return;
            if (disposing)
            {
                _shopContext.Dispose();
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
