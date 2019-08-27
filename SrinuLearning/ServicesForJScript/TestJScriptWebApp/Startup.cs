using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TestJScriptWebApp.Startup))]
namespace TestJScriptWebApp
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
