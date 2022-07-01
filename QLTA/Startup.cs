using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QLTA.Startup))]
namespace QLTA
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
