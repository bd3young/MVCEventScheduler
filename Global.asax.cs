using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using MVCEventScheduler.DAL;
using System.Data.Entity.Infrastructure.Interception;

namespace MVCEventScheduler
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            DbInterception.Add(new EventInterceptorTransientErrors());
            DbInterception.Add(new EventInterceptorLogging());
        }
    }
}
