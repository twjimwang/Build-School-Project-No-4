using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Build_School_Project_No_4.Startup))]
namespace Build_School_Project_No_4
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
