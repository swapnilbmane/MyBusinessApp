using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyBusinessApp.Startup))]
namespace MyBusinessApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
