using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Demo_B2.Startup))]
namespace Demo_B2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
