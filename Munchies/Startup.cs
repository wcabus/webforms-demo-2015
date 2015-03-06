using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Munchies.Startup))]
namespace Munchies
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
