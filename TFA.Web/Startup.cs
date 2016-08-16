using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TFA.Web.Startup))]
namespace TFA.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
