using System.Web;
using System.Web.Mvc;
using True.Kentico.Forms.Forms.FormParts;

namespace True.Kentico.Forms.Infrastructure
{
    class KenticoFormsInitialisationModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            ControlRendererRegistrar.InitialiseFormControls();
            ModelBinders.Binders.Add(typeof(IForm), new FormModelBinder());
        }

        public void Dispose()
        { 
        }
    }
}
