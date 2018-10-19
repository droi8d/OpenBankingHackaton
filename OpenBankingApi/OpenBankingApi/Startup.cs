using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OpenBankingApi.Startup))]
namespace OpenBankingApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
