using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UMedia.Startup))]
namespace UMedia
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
