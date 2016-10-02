using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ShipsService.Startup))]
namespace ShipsService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
