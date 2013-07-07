using System.Web;
using System.Web.Optimization;

namespace CageFlix
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/js/bootstrap").Include(
            //            "~/Assets/js/bootstrap/*.js"));

            bundles.Add(new StyleBundle("~/bundles/css/bootstrap")
                .Include("~/Assets/css/bootstrap.css")
                .Include("~/Assets/css/responsive.css"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval")
                .Include("~/Assets/js/jquery.validate.min.js")
                .Include("~/Assets/js/jquery.validate.unobtrusive.min.js"));
        }
    }
}