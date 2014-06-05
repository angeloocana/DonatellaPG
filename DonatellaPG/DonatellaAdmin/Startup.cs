using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DonatellaAdmin.Startup))]
namespace DonatellaAdmin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
