using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using True.Kentico.Forms.Forms.FormParts;
using True.Kentico.Forms.Infrastructure;
using True.Kentico.Forms.Web.Binders;
using True.Kentico.Forms.Web.Models;
using True.Kentico.Forms.Web.Renderers;

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

            ControlRendererRegistrar.RegisterCustomRenderer(ControlType.Label, new CustomLabelRenderer());
            ModelBinders.Binders.Add(typeof(ShortForm), new ShortFormModelBinder());
        }
    }
}
