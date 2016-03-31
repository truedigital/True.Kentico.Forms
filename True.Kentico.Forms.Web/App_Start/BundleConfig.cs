using System.Web.Optimization;

namespace True.Kentico.Forms.Web
{
	public class BundleConfig
	{
		// For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                                    "~/Assets/js/vendor/jquery-{version}.js"));
            
			// Use the development version of Modernizr to develop with and learn from. Then, when you're
			// ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
			bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
									"~/Assets/js/vendor/modernizr-*"));

			bundles.Add(new ScriptBundle("~/bundles/js").Include("~/Assets/js/partials/_form-submit.js",
                "~/Assets/js/partials/_validation.js"));

			bundles.Add(new StyleBundle("~/Content/css").Include("~/Assets/css/style.css"));
		}
	}
}
