using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EventosUy.Startup))]
namespace EventosUy
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
