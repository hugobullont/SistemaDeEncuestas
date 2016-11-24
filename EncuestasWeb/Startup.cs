using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EncuestasWeb.Startup))]
namespace EncuestasWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
