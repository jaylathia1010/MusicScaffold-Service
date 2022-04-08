using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MusicScaffold.Startup))]
namespace MusicScaffold
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
