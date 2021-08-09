using Owin;
using Microsoft.Owin;

[assembly: OwinStartup(typeof(FA.JustBlog.MVC.Startup))]
namespace FA.JustBlog.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
