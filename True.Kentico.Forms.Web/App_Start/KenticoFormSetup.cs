using System.Web;
using System.Web.Mvc;
using True.Kentico.Forms.Forms.FormParts;
using True.Kentico.Forms.Infrastructure;
using True.Kentico.Forms.Web;

[assembly: PreApplicationStartMethod(typeof(KenticoFormSetup), "Setup")]

namespace True.Kentico.Forms.Web
{
    public class KenticoFormSetup
    {
        public static void Setup()
        {
            ModelBinders.Binders.Add(typeof(IForm), new FormModelBinder());
            ControlRendererRegistrar.InitialiseFormControls();
        }
    }
}