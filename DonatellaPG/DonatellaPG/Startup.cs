using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DonatellaPG.Startup))]
namespace DonatellaPG
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
