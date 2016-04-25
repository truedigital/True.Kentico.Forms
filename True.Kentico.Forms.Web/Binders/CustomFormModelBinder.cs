using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using True.Kentico.Forms.Forms.FormParts;
using True.Kentico.Forms.Web.Models;

namespace True.Kentico.Forms.Web.Binders
{
    public class CustomFormModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var request = controllerContext.HttpContext.Request;

            var formName = request.Form.Get("formname");

            var form = new ShortForm(formName);

            foreach (var control in form.Controls)
            {
                if (control is IFileControl)
                {
                    var fileControl = control as IFileControl;
                    fileControl.SubmittedValue = request.Files[control.Name]?.FileName;
                    fileControl.SubmittedData = request.Files[control.Name]?.InputStream;
                }
                else
                {
                    control.SubmittedValue = request.Form.Get(control.Name);
                }
            }

            return form;
        }
    }
}