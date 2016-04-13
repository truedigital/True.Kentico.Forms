using System.Web.Mvc;
using CMS.OnlineForms;
using CMS.SiteProvider;
using True.Kentico.Forms.Forms;
using True.Kentico.Forms.Forms.FormParts;

namespace True.Kentico.Forms.Infrastructure
{
    public class FormModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var request = controllerContext.HttpContext.Request;

            var formName = request.Form.Get("formname");
            var formInfo = BizFormInfoProvider.GetBizFormInfo(formName, SiteContext.CurrentSiteID);

            var formFactory = new FormFactory(new Forms.ControlFactory.ControlFactory());
            var form = formFactory.Create(formInfo);

            foreach (var control in form.Controls)
            {
                control.SubmittedValue = control.Type == ControlType.UploadFile ?
                    request.Files[control.Name]?.FileName :
                    request.Form.Get(control.Name);
            }

            return form;
        }
    }
}