using System;

namespace JustCreativePublishings.Infrastructure.IoC.Interfaces
{
    public interface IDependencyResolver
    {
        T GetService<T>();
    }
}
