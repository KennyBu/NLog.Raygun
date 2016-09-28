using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NLog.Raygun.WebTestApp.Startup))]
namespace NLog.Raygun.WebTestApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
