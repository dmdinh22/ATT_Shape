using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ATT_Shape3.Startup))]
namespace ATT_Shape3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
