using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IqansAppsForCTS.Startup))]
namespace IqansAppsForCTS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
