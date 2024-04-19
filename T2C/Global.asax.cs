using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using T2C.AutoMapper;
using T2C.Login;


namespace T2C
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutoMapperConfig.RegisterMapping();
           }

    }
}
