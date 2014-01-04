using System;
using System.Collections.Generic;
using System.Web.Mvc;
using JustCreativePublishings.Domain;
using JustCreativePublishings.Infrastructure.IoC;
using JustCreativePublishings.Interfaces;
using JustCreativePublishings.Interfaces.Services;
using JustCreativePublishings.Services;
using Ninject;
using Ninject.Web.Common;

namespace JustCreativePublishings.Web.Infrastructure
{
    public class ServicesDependencyResolver : BaseDependencyResolver, IDependencyResolver
    {
        public ServicesDependencyResolver() : base()
        {
            AddBindings();
        }

        private void AddBindings()
        {
            Kernel.Bind<JustCreativePublishingsContext>().ToSelf().InRequestScope();
            Kernel.Bind<IPostService>().To<PostService>().InRequestScope();
            Kernel.Bind<ITagService>().To<TagService>().InRequestScope();
            Kernel.Bind<IUserService>().To<UserService>().InRequestScope();
            Kernel.Bind<IVoteService>().To<VoteService>().InRequestScope();
            Kernel.Bind<IStatisticsService>().To<StatisticsService>().InRequestScope();
            Kernel.Bind<IEmailService>().To<EmailService>().InRequestScope();
            Kernel.Bind<IAdminService>().To<AdminService>().InRequestScope();
        }

        public object GetService(Type serviceType)
        {
            return Kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return Kernel.GetAll(serviceType);
        }
    }
}