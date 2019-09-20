using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyDoctor.Startup))]
namespace MyDoctor
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
