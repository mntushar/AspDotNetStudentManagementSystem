using System.Web;
using System.Web.Optimization;

namespace StudentManagementSystem
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
                      "~/Content/font-awesome.css",
                      "~/Content/Site.css"));

            bundles.Add(new StyleBundle("~/Content/admin/css").Include(
                      "~/Content/admin/plugins/fontawesome-free/css/all.min.css",
                      "~/Content/admin/plugins/tempusdominus-bootstrap-4/css/tempusdominus-bootstrap-4.min.css",
                      "~/Content/admin/plugins/icheck-bootstrap/icheck-bootstrap.min.css",
                      "~/Content/admin/plugins/jqvmap/jqvmap.min.css",
                      "~/Content/admin/dist/css/adminlte.min.css",
                      "~/Content/admin/plugins/overlayScrollbars/css/OverlayScrollbars.min.css",
                      "~/Content/admin/plugins/daterangepicker/daterangepicker.css",
                      "~/Content/admin/plugins/summernote/summernote-bs4.min.css"));

            bundles.Add(new StyleBundle("~/Content/admin/js").Include(
                      "~/Content/admin/plugins/jquery-ui/jquery-ui.min.js",
                      "~/Content/admin/plugins/chart.js/Chart.min.js",
                      "~/Content/admin/plugins/sparklines/sparkline.js",
                      "~/Content/admin/plugins/jqvmap/jquery.vmap.min.js",
                      "~/Content/admin/plugins/jqvmap/maps/jquery.vmap.usa.js",
                      "~/Content/admin/plugins/moment/moment.min.js",
                      "~/Content/admin/plugins/tempusdominus-bootstrap-4/js/tempusdominus-bootstrap-4.min.js",
                      "~/Content/admin/plugins/summernote/summernote-bs4.min.js",
                      "~/Content/admin/plugins/overlayScrollbars/js/jquery.overlayScrollbars.min.js",
                      "~/Content/admin/dist/js/adminlte.js",
                      "~/Content/admin/dist/js/demo.js",
                      "~/Content/admin/dist/js/pages/dashboard.js"));
        }
    }
}
