using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VitaDiet.Startup))]
namespace VitaDiet
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
