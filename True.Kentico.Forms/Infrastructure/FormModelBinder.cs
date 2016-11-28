using System;
using System.Globalization;
using System.Linq;
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
                if (control is IFileControl)
                {
                    var fileControl = control as IFileControl;
                    fileControl.SubmittedValue = request.Files[control.Name]?.FileName;
                    fileControl.SubmittedData = request.Files[control.Name]?.InputStream;
                }
                // this (naively) assumes that a checkbox is a single item
                else if (control.Type == ControlType.CheckBox/* || control.Type == ControlType.RadioButton*/)
                {
                    var value = request.Form.Get(control.Name); // post form values for these types returns either no value or the name, so a value implies true
                    control.SubmittedValue = value?.Equals(control.Name, StringComparison.OrdinalIgnoreCase).ToString();
                }
                else
                {
                    var submittedValue = request.Form.Get(control.Name);
                    if (control.Type == ControlType.Calendar)
                    {
                        if (submittedValue == "")
                            control.SubmittedValue = null;
                        else
                        {
                            DateTime date;
                            var enGB = new CultureInfo("en-GB");
                            if (DateTime.TryParseExact(submittedValue, "dd/MM/yyyy", enGB, DateTimeStyles.None, out date))
                            {
                                control.SubmittedValue = date.ToString("yyyy-MM-dd HH:mm:ss");
                            }

                        }
                    }
                    else
                    {
                        control.SubmittedValue = submittedValue;
                    }
                }
            }

            return form;
        }
    }
}