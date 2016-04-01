using System.Web.Mvc;
using CMS.OnlineForms;
using CMS.SiteProvider;

namespace True.Kentico.Forms.Forms.FormParts
{
    public class FormModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var request = controllerContext.HttpContext.Request;

            var formName = request.Form.Get("formname");
            var formInfo = BizFormInfoProvider.GetBizFormInfo(formName, SiteContext.CurrentSiteID);

            var formFactory = new FormFactory(new ControlFactory.ControlFactory());
            var form = formFactory.Create(formInfo);
            foreach (var control in form.Controls)
                control.SubmittedValue = request.Form.Get(control.Name);

            return form;
        }
    }
}