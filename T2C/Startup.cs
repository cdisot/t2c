using Microsoft.Owin;
using Owin;
using T2C;

[assembly: OwinStartup(typeof(Startup))]
namespace T2C
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
