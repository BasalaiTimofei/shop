using System;
using System.Collections.Generic;

namespace Shop.Data.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Predicate<T> predicate);
        T Get(string id);
        void Create(T item);
        void Update(T item);
        void Delete(string id);
    }
}