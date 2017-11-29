using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Personal_Inventory_Management.Startup))]
namespace Personal_Inventory_Management
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
