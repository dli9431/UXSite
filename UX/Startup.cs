using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UX.Startup))]
namespace UX
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
