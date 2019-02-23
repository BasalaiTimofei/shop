using AutoMapper;
using Ninject.Modules;
using Shop.Business.Infrastructure.Mapping;
using Shop.Business.Services;
using Shop.Data.Context;
using Shop.Data.Interfaces;
using Shop.Data.Repositories;

namespace Shop.Business.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        private readonly ShopContext _shopContext;
        public ServiceModule(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }

        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>().WithConstructorArgument(_shopContext);

            Bind<IMapper>().ToMethod(ctx =>
                    new Mapper(new MapperConfiguration(cfg =>
                        cfg.AddProfile(new ProductMappingProfile()))))
                .WhenInjectedInto<ProductService>();
        }
    }
}
