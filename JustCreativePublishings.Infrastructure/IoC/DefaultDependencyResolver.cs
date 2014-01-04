using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JustCreativePublishings.Infrastructure.IoC.Exceptions;

namespace JustCreativePublishings.Infrastructure.IoC
{
    public class DefaultDependencyResolver : BaseDependencyResolver
    {
        public object GetService(Type serviceType)
        {
            throw new DependencyResolverException("DefaultDependencyResolver must be replaced");
        }
    }
}
