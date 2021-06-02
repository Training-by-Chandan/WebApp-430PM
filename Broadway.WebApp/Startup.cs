using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Broadway.WebApp.Startup))]
namespace Broadway.WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
