using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JustCreativePublishings.Infrastructure.IoC.Interfaces;

namespace JustCreativePublishings.Infrastructure.IoC
{
    public static class DependencyResolver
    {
        public static IDependencyResolver Current { get; private set; }

        static DependencyResolver()
        {
            Current = new DefaultDependencyResolver();
        }

        public static void SetResolver(IDependencyResolver dependencyResolver)
        {
            if (dependencyResolver == null)
                throw new ArgumentNullException();
            Current = dependencyResolver;
        }
    }
}
