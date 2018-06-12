using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SellBook.Startup))]
namespace SellBook
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
