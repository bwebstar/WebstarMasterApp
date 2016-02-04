using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebstarMasterApp.Startup))]
namespace WebstarMasterApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
