using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCEventScheduler.Startup))]
namespace MVCEventScheduler
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
