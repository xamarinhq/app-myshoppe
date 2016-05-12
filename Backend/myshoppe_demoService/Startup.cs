using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(myshoppe_demoService.Startup))]

namespace myshoppe_demoService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}