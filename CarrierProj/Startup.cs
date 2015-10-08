using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CarrierProj.Startup))]
namespace CarrierProj
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
