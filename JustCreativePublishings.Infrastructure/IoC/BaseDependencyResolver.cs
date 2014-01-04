using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JustCreativePublishings.Infrastructure.IoC.Interfaces;
using Ninject;

namespace JustCreativePublishings.Infrastructure.IoC
{
    public abstract class BaseDependencyResolver : IDependencyResolver
    {
        protected IKernel Kernel;

        protected BaseDependencyResolver()
        {
            Kernel = new StandardKernel();
        }

        public virtual T GetService<T>()
        {
            return Kernel.TryGet<T>();
        }
    }
}
