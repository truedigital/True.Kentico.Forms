using System.Web.Mvc;
using CMS.OnlineForms;
using CMS.SiteProvider;
using True.KenticoForms;

namespace True.Kentico.Forms.Forms
{
    public class FormModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var request = controllerContext.HttpContext.Request;

            var formName = request.Form.Get("form-name");
            var formInfo = BizFormInfoProvider.GetBizFormInfo(formName, SiteContext.CurrentSiteID);

            var formFactory = new FormFactory(new KenticoForms.ControlFactory.ControlFactory());
            var form = formFactory.Create(formInfo);
            foreach (var control in form.Controls)
                control.SubmittedValue = request.Form.Get(control.Name);

            return form;
        }
    }
}