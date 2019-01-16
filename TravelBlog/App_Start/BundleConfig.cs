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

            bundles.Add(new ScriptBundle("~/bundles/jqueryscrollto").Include(
                        "~/Scripts/Custom/jquery.scrollTo.min.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/entry").Include(
                "~/Scripts/Custom/disqus.js",
                "~/Scripts/Custom/stickyRightAside.js",
                "~/Scripts/Custom/scrollUp.js"));

            bundles.Add(new ScriptBundle("~/bundles/entries").Include(
                "~/Scripts/Custom/scrollUp.js",
                "~/Scripts/Custom/stickyRightAside.js"));

            bundles.Add(new ScriptBundle("~/bundles/spec-entries").Include(
                "~/Scripts/Custom/scrollUp.js",
                "~/Scripts/Custom/stickyRightAside_spec.js",
                "~/Scripts/Custom/stickyTitleBar.js"));

            bundles.Add(new ScriptBundle("~/bundles/galleries").Include(
                "~/Scripts/Custom/scrollUp.js",
                "~/Scripts/Custom/stickyRightAside.js",
                "~/Scripts/Custom/imageScale.js"));

            bundles.Add(new ScriptBundle("~/bundles/spec-galleries").Include(
                "~/Scripts/Custom/scrollUp.js",
                "~/Scripts/Custom/stickyRightAside_spec.js",
                "~/Scripts/Custom/imageScale.js",
                "~/Scripts/Custom/stickyTitleBar.js"));

            bundles.Add(new ScriptBundle("~/bundles/gallery").Include(
                "~/Scripts/Custom/fotoPreview.js",
                "~/Scripts/Custom/scrollUp.js",
                "~/Scripts/Custom/stickyRightAside_spec.js",
                "~/Scripts/Custom/imageScale.js",
                "~/Scripts/Custom/stickyTitleBar.js"));

            bundles.Add(new ScriptBundle("~/bundles/index").Include(
                "~/Scripts/Custom/jquery.scrollTo.min.js",
                "~/Scripts/Custom/imageScale.js",
                "~/Scripts/Custom/stickyRightAside.js",
                "~/Scripts/Custom/indexScrollToContact.js"));

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
                "~/Content/Custom/index2.css"
            ));

            bundles.Add(new StyleBundle("~/Content/Custom/entries").Include(
                "~/Content/Custom/general.css",
                "~/Content/Custom/entries.css"
            ));

            bundles.Add(new StyleBundle("~/Content/Custom/spec-entries").Include(
                "~/Content/Custom/general.css",
                "~/Content/Custom/entries.css",
                "~/Content/Custom/spec-entries.css"
            ));

            bundles.Add(new StyleBundle("~/Content/Custom/entry").Include(
                "~/Content/Custom/general.css",
                "~/Content/Custom/entry.css"
            ));

            bundles.Add(new StyleBundle("~/Content/Custom/galleries").Include(
                "~/Content/Custom/general.css",
                "~/Content/Custom/galleries.css"
            ));

            bundles.Add(new StyleBundle("~/Content/Custom/gallery").Include(
                "~/Content/Custom/general.css",
                "~/Content/Custom/gallery.css"
            ));

            bundles.Add(new StyleBundle("~/Content/Custom/contact").Include(
                "~/Content/Custom/general.css",
                "~/Content/Custom/contact.css"
            ));

            bundles.Add(new StyleBundle("~/Content/Custom/nocontent").Include(
                "~/Content/Custom/general.css",
                "~/Content/Custom/nocontent.css"
            ));
        }
    }
}
