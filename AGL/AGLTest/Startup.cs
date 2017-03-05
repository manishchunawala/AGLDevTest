using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(AGLTest.Startup))]

namespace AGLTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
