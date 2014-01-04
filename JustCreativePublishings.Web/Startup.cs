using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JustCreativePublishings.Web.Startup))]
namespace JustCreativePublishings.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
