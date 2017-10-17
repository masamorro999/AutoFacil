using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AutosRa.Backend.Startup))]
namespace AutosRa.Backend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
