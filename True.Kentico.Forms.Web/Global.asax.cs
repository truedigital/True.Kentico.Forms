using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
//using True.Kentico.Forms.Forms.FormParts;
//using True.Kentico.Forms.Infrastructure;

namespace True.Kentico.Forms.Web
{
	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);

            //ModelBinders.Binders.Add(typeof(IForm), new FormModelBinder());
            //ControlRendererRegistrar.InitialiseFormControls();
		}
	}
}
