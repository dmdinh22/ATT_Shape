using System.Web;
using System.Web.Optimization;

namespace ATT_Shape3
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
					  "~/Scripts/bootstrap.js",
					  "~/Scripts/respond.js"));

			// adding AngularJS
			bundles.Add(new ScriptBundle("~/bundles/angular").Include(
								"~/Scripts/angular.js",
								"~/scripts/angular-animate.js"));
			//adding angular app
			bundles.Add(new ScriptBundle("~/bundles/app").Include(
								"~/Scripts/App/attApp.js",
								"~/scripts/App/attApp.Services.People.js"));

			bundles.Add(new StyleBundle("~/Content/css").Include(
					  "~/Content/bootstrap.css",
					  "~/Content/site.css",
                      "~/Content/twilio-chat.css"
                      ));

            //adding Twilio app
            bundles.Add(new ScriptBundle("~/bundles/twiliochat").Include(
                   
                      "~/Scripts/twiliochat.js",
                      "~/Scripts/dateformatter.js"));

            BundleTable.EnableOptimizations = false; 
        }
	}
}
