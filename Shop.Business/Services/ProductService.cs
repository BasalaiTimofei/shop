using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Shop.Business.Infrastructure;
using Shop.Business.Interfaces;
using Shop.Business.Models;
using Shop.Data.Interfaces;

namespace Shop.Business.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public Product Get(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ValidationException("Поле не заполнено", "");
            var product = _uow.Products.Get(id);
            if (product == null)
                throw new ValidationException("Продукт не найден", "");

            return _mapper.Map<Data.Models.Product, Product>(product);
        }

        public IEnumerable<Product> GetAll()
        {
            var products = _uow.Products.GetAll();
            if (products == null)
                throw new ValidationException("Список пуст", "");
            return products.Select(s => _mapper.Map<Product>(s));
        }

        public void Add(Product product)
        {
            if (product == null || product.Price < 0
                                || string.IsNullOrEmpty(product.Name)
                                || !ProductIsInDb(
                                    p => string.Equals(p.Name, product.Name, StringComparison.CurrentCultureIgnoreCase),
                                    out var videoDb))
                throw new ValidationException("Модель невалидна", "");

            _uow.Products.Create(_mapper.Map<Data.Models.Product>(product));
        }

        private bool ProductIsInDb(Predicate<Data.Models.Product> condition,
            out IEnumerable<Data.Models.Product> product)
        {
            product = _uow.Products.Find(condition);
            return product.Any();
        }

        public void Dispose()
        {
            _uow.Dispose();
        }

        ~ProductService()
        {
            Dispose();
        }
    }
}
