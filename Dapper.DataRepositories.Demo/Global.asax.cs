using Autofac;
using Autofac.Integration.WebApi;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Dapper.DataRepositories.Demo
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Dependency injection configuration
            IoC.Instance.RegisterApiControllers(Assembly.GetExecutingAssembly());
            var apiControllersResolver = new AutofacWebApiDependencyResolver(IoC.Instance.GetComponentsContainer());
            GlobalConfiguration.Configuration.DependencyResolver = apiControllersResolver;
        }
    }
}
