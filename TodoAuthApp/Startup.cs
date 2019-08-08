using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TodoAuthApp.Startup))]
namespace TodoAuthApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
