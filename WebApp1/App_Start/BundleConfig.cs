using System.Web;
using System.Web.Optimization;

namespace WebApp
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/css/bootstrap.css",
                      "~/css/Site.css",
                      "~/css/font-awesome.css",
                      "~/css/skdslider.css"
                      ));
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/js/jquery-1.11.1.min.js"
                        ));
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                      "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
                        "~/js/bootstrap.min.js",
                        "~/js/easing.js",
                        "~/js/minicart.min.js",
                        "~/js/move-top.js",
                        "~/js/responsiveslides.min.js",
                        "~/js/skdslider.min.js",
                        "~/js/localize.js",
                        "~/js/Function.js"
            ));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));



        }
    }
}
