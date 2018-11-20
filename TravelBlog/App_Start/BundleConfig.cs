using System.Web;
using System.Web.Optimization;

namespace TravelBlog
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/Custom/colors.css",
                      "~/Content/Custom/contanct.css",
                      "~/Content/Custom/entries.css",
                      "~/Content/Custom/entry.css",
                      "~/Content/Custom/galleries.css",
                      "~/Content/Custom/gallery.css",
                      "~/Content/Custom/general.css",
                      "~/Content/Custom/index.css",
                      "~/Content/Custom/spec-entries.css"
                      ));

            bundles.Add(new StyleBundle("~/Content/Fontello").Include(
                "~/Content/Fontello/animation.css",
                "~/Content/Fontello/fontello-codes.css",
                "~/Content/Fontello/fontello-embedded.css",
                "~/Content/Fontello/fontello-ie7-codes.css",
                "~/Content/Fontello/fontello-ie7.css",
                "~/Content/Fontello/fontello.css"
            ));

            bundles.Add(new StyleBundle("~/Content/Custom/index").Include(
                "~/Content/Custom/general.css",
                "~/Content/Custom/index.css"
            ));
        }
    }
}
