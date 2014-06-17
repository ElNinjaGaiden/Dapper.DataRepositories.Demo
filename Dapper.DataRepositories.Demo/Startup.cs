using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Dapper.DataRepositories.Demo.Startup))]
namespace Dapper.DataRepositories.Demo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
