using System.Web.Mvc;
using System.Web.Routing;

namespace MVCEventScheduler
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Employee", //route
                "Employee/{action}/{name}", //URL with parameters
                new { controller = "Event", action = UrlParameter.Optional, name = UrlParameter.Optional } // parameter
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
