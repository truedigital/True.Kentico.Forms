using System.Web;
using System.Web.Mvc;
using True.Kentico.Forms.Forms.FormParts;
using True.Kentico.Forms.Infrastructure;

[assembly:PreApplicationStartMethod(typeof(KenticoFormSetup), "Setup")]

namespace True.Kentico.Forms.Infrastructure
{
    public class KenticoFormSetup
    {
        public static void Setup()
        {
            ControlRendererRegistrar.InitialiseFormControls();
            ModelBinders.Binders.Add(typeof(IForm), new FormModelBinder());
        }
    }
}