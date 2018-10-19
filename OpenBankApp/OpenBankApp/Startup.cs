using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OpenBankApp.Startup))]
namespace OpenBankApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
