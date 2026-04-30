using System.Web;
using System.Web.Optimization;

namespace ChecklistForm
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.IgnoreList.Clear();
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/Scripts/js").Include(
                     "~/Scripts/CommonScript.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/Site.css",
             "~/Content/style.css",
             "~/Content/demo.css",
             "~/Content/jquery-ui-1.12.1.css"
            ));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));


            bundles.Add(new StyleBundle("~/font-awesome-4.7.0/font-awesome-4.7.0/css").Include(
                "~/font-awesome-4.7.0/font-awesome-4.7.0/css/font-awesome.min.css",
                "~/font-awesome-4.7.0/icons/ionicons.min.css"
                ));

            bundles.Add(new StyleBundle("~/AdminStyle/css").Include(
         "~/AdminStyle/bootstrap/css/bootstrap.css",
          "~/AdminStyle/plugins/select2/select2.css",
                "~/AdminStyle/plugins/datatables/jquery.dataTables.css",
                "~/AdminStyle/plugins/datatables/dataTables.bootstrap.css",

                 "~/AdminStyle/dist/css/AdminLTE.css",
                 "~/AdminStyle/dist/css/skins/_all-skins.css",
                 "~/AdminStyle/plugins/morris/morris.css",
                 "~/AdminStyle/plugins/datepicker/datepicker3.css"));

            bundles.Add(new ScriptBundle("~/AdminStyle/jquery").Include(
                "~/AdminStyle/plugins/jQuery/jquery-2.2.3.js",
                "~/AdminStyle/bootstrap/js/bootstrap.js",
                "~/AdminStyle/plugins/slimScroll/jquery.slimscroll.js",
                "~/AdminStyle/plugins/fastclick/fastclick.js",
                "~/AdminStyle/dist/js/app.js",
                "~/AdminStyle/plugins/select2/select2.full.js",
                "~/AdminStyle/plugins/select2/select2.js",
                "~/AdminStyle/dist/js/demo.js",
                "~/AdminStyle/plugins/input-mask/jquery.inputmask.js",
                "~/AdminStyle/plugins/input-mask/jquery.inputmask.extensions.js",
                "~/AdminStyle/plugins/input-mask/jquery.inputmask.date.extensions.js",

                "~/AdminStyle/plugins/datatables/jquery.dataTables.js",
                "~/AdminStyle/plugins/datatables/dataTables.bootstrap.js",
                "~/AdminStyle/plugins/datepicker/bootstrap-datepicker.js"
                ));

            BundleTable.EnableOptimizations = true;
        }
    }
}