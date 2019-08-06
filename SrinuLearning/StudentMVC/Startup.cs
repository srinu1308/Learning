using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StudentMVC.Startup))]
namespace StudentMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
