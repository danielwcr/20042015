using System.Web;
using System.Web.Optimization;

namespace Lab.Presentation.MVC
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/globalize.js",
                        "~/Scripts/cldr.js",
                        "~/Scripts/jquery.validate.js",
                        "~/Scripts/jquery.validate.unobtrusive.js"
                        //,                        "~/Scripts/jquery.validate.globalize.js"
                        
                        )
                        .IncludeDirectory("~/Scripts/cldr/", "*.js", true)
                        .IncludeDirectory("~/Scripts/globalize/", "*.js", true)
                        
                        
                        );

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Content/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                        "~/Content/site.css",
                        "~/Content/bootstrap.css",
                        "~/Content/bootstrap-theme.css"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                       "~/Scripts/angular.js"));

            bundles.Add(new ScriptBundle("~/bundles/app").IncludeDirectory(
                       "~/App_Script/", "*.js", true));


            BundleTable.EnableOptimizations = false;
        }
    }
}