using System;
using Shop.Data.Models;

namespace Shop.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Product> Products { get; }
        void Save();
    }
}
