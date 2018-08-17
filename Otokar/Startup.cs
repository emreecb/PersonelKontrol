using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Otokar.Startup))]
namespace Otokar
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
