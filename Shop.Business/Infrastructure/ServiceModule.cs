using Ninject.Modules;
using Shop.Data.Context;
using Shop.Data.Interfaces;
using Shop.Data.Repositories;

namespace Shop.Business.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>();
        }
    }
}
