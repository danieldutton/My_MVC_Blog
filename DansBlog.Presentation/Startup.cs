using DansBlog.DataAccess;
using Microsoft.Owin;
using Owin;
using System.Data.Entity;

[assembly: OwinStartupAttribute(typeof(DansBlog.Startup))]
namespace DansBlog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            
            DbConfiguration.SetConfiguration(new BlogConfiguration());
        }
    }
}
