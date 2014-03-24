using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(oagum0._01.Startup))]
namespace oagum0._01
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
