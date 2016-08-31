using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VidlyMovies.Startup))]
namespace VidlyMovies
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
