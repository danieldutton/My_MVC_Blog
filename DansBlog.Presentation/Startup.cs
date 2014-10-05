using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DansBlog.Startup))]
namespace DansBlog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
