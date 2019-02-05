using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MRWorld.Startup))]
namespace MRWorld
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
