using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JustCreativePublishings.WebForms.Startup))]
namespace JustCreativePublishings.WebForms
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
