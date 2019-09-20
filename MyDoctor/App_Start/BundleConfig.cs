using System.Web;
using System.Web.Optimization;

namespace MyDoctor
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"  ));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js",
                      "~/Templetes/Contact/vendor/jquery/jquery-3.2.1.min.js",
                      "~/Templetes/Contact/vendor/bootstrap/js/popper.js",
                      "~/Templetes/Contact/vendor/bootstrap/js/bootstrap.min.js",
                      "~/Templetes/Contact/vendor/select2/select2.min.js",
                      "~/Templetes/Contact/vendor/tilt/tilt.jquery.min.js",
                      "~/Templetes/Contact/js/main.js",
                      "~/Templetes/Index/js/jquery-1.12.1.min.js",
                      "~/Templetes/Index/js/popper.min.js",
                      "~/Templetes/Index/js/bootstrap.min.js",
                      "~/Templetes/Index/js/owl.carousel.min.js",
                      "~/Templetes/Index/js/jquery.nice-select.min.js",
                      "~/Templetes/Index/js/jquery.ajaxchimp.min.js",
                      "~/Templetes/Index/js/jquery.form.js",
                      "~/Templetes/Index/js/jquery.validate.min.js",
                      "~/Templetes/Index/js/mail-script.js",
                      "~/Templetes/Index/js/contact.js",
                      "~/Templetes/Index/js/custom.js",
                      "~/Templetes/LogIn/vendor/jquery/jquery-3.2.1.min.js",
                      "~/Templetes/LogIn/vendor/animsition/js/animsition.min.js",
                      "~/Templetes/LogIn/vendor/bootstrap/js/popper.js",
                      "~/Templetes/LogIn/vendor/bootstrap/js/bootstrap.min.js",
                      "~/Templetes/LogIn/vendor/select2/select2.min.js",
                      "~/Templetes/LogIn/vendor/daterangepicker/moment.min.js",
                      "~/Templetes/LogIn/vendor/daterangepicker/daterangepicker.js",
                      "~/Templetes/LogIn/vendor/countdowntime/countdowntime.js",
                      "~/Templetes/LogIn/js/main.js",
                      "~/Templetes/LogIn2/JavaScript.js",
                      "~/Templetes/Search/Script.js"
                      



                      ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Templetes/Contact/vendor/bootstrap/css/bootstrap.min.css",
                      "~/Templetes/Contact/fonts/font-awesome-4.7.0/css/font-awesome.min.css",
                       "~/Templetes/Contact/vendor/animate/animate.css",
                       "~/Templetes/Contact/vendor/css-hamburgers/hamburgers.min.css",
                       "~/Templetes/Contact/vendor/select2/select2.min.css",
                       "~/Templetes/Contact/css/util.css",
                       "~/Templetes/Contact/css/main.css",
                        "~/Templetes/Index/css/bootstrap.min.css",
                       "~/Templetes/Index/css/animate.css",
                       "~/Templetes/Index/css/owl.carousel.min.css",
                       "~/Templetes/Index/css/themify-icons.css",
                       "~/Templetes/Index/css/flaticon.css",
                       "~/Templetes/Index/css/magnific-popup.css",
                       "~/Templetes/Index/css/nice-select.css",
                       "~/Templetes/Index/css/style.css",
                       "~/Templetes/Index/css/slick.css",
                       "~/Templetes/LogIn/images/icons/favicon.ico",
                       "~/Templetes/LogIn/vendor/bootstrap/css/bootstrap.min.css",
                       "~/Templetes/LogIn/fonts/font-awesome-4.7.0/css/font-awesome.min.css",
                       "~/Templetes/LogIn/fonts/Linearicons-Free-v1.0.0/icon-font.min.css",
                       "~/Templetes/LogIn/vendor/animate/animate.css",
                       "~/Templetes/LogIn/vendor/css-hamburgers/hamburgers.min.css",
                       "~/Templetes/LogIn/vendor/animsition/css/animsition.min.css",
                       "~/Templetes/LogIn/vendor/select2/select2.min.css",
                       "~/Templetes/LogIn/vendor/daterangepicker/daterangepicker.css",
                       "~/Templetes/LogIn/css/util.css",
                       "~/Templetes/LogIn/css/main.css",
                       "~/Templetes/LogIn2/Style.css",
                       "~/Templetes/Search/Style.css"


















                       ));
        }
    }
}
