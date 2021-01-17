using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(vidly_aspnetmvc.Startup))]
namespace vidly_aspnetmvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
