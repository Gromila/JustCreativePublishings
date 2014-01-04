using JustCreativePublishings.Infrastructure.IoC;
using JustCreativePublishings.Interfaces;
using JustCreativePublishings.UoW;
using Ninject;

namespace JustCreativePublishings.Services
{
    public class UnitOfWorkDependencyResolver : BaseDependencyResolver
    {
        public UnitOfWorkDependencyResolver()
        {
            Kernel = new StandardKernel();
            AddBindings();
        }

        private void AddBindings()
        {
            Kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InSingletonScope();
        }
    }
}
