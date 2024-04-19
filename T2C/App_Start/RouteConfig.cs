using System.Web.Mvc;
using System.Web.Routing;

namespace T2C
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Page", action = "t2c", id = UrlParameter.Optional }
            );
        }
    }
}
