using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JustCreativePublishings.Infrastructure.IoC;
using JustCreativePublishings.Interfaces;
using JustCreativePublishings.Interfaces.Services;

namespace JustCreativePublishings.Services
{
    public abstract class BaseService : IService
    {
        private bool disposed = false;

        protected IUnitOfWork UnitOfWork;

        protected BaseService()
        {
            DependencyResolver.SetResolver(new UnitOfWorkDependencyResolver());
            UnitOfWork = DependencyResolver.Current.GetService<IUnitOfWork>();
        }
        
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    UnitOfWork.Dispose();
                }
            }
            this.disposed = true;
        }

        void IDisposable.Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
