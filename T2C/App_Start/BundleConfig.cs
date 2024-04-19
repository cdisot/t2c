using System.Web.Optimization;

namespace T2C
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/owl.js",
                        "~/Scripts/jquery_002.js",
                        "~/Scripts/jquery-1.js",
                        "~/Scripts/modernizr.js",
                        "~/Scripts/google_analytics_auto.js",
                        "~/Scripts/ga.js",
                        "~/Scripts/script.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/style_002.css",
                      "~/Content/owl_002.css",
                      "~/Content/owl.css",
                      "~/Content/custom.css",
                      "~/Content/style.css",
                      "~/Content/index.css"
                      ));

            bundles.Add(new ScriptBundle("~/angular/angular").Include(

               "~/Scripts/angular.js",
               "~/Scripts/angular-route.js",
               "~/Scripts/angular.min.js",
               "~/Scripts/Cell/CModule.js",
               "~/Scripts/Cell/CController.js",
               "~/Scripts/Cell/CService.js"));
        
        }
    }
}
