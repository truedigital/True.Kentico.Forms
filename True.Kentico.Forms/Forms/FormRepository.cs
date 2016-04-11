using System;
using System.Linq;
using System.Text;
using CMS.DataEngine;
using CMS.FormEngine;
using CMS.MacroEngine;
using CMS.OnlineForms;
using CMS.SiteProvider;
using True.Kentico.Forms.Forms.FormParts;

namespace True.Kentico.Forms.Forms
{
    public class FormRepository : IFormRepository
    {
        private readonly IFormFactory _formFactory;

        //public FormRepository(IFormFactory formFactory)
        //{
        //    _formFactory = formFactory;
        //}

        public FormRepository()
        {
            _formFactory = new FormFactory(new ControlFactory.ControlFactory());
        }

        public void Submit(IForm form)
        {
            var isValid = true;
            var errors = new StringBuilder();
            try
            {
                var formInfo = BizFormInfoProvider.GetBizFormInfo(form.Name, SiteContext.CurrentSiteID);
                var dataClassInfo = DataClassInfoProvider.GetDataClassInfo(formInfo.FormClassID);

                var item = new BizFormItem(dataClassInfo.ClassName);

                foreach (var control in form.Controls)
                {
                    if (control.IsValid())
                    {
                        item.SetValue(control.Name, control.SubmittedValue);
                    }
                    else
                    {
                        isValid = false;
                        errors.AppendLine($"{control.Name} has validation errors. Please review.");
                    }
                }

                if (!isValid)
                {
                    throw new InvalidOperationException(errors.ToString());
                }

                item.SetValue("FormInserted", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                item.SetValue("FormUpdated", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));


               BizFormItemProvider.SetItem(item);
                BizFormInfoProvider.RefreshDataCount(formInfo.FormName, formInfo.FormSiteID);
            }
            catch (Exception ex)
            {

                throw new InvalidOperationException("An unknown error occured while saving the form. Please contact our support team.");
            }
        }

        public IForm GetForm(string formName)
        {
            BizFormInfo formObject = BizFormInfoProvider.GetBizFormInfo(formName, SiteContext.CurrentSiteID);

            if (formObject != null)
            {
                var formInfo = _formFactory.Create(formObject);
                return formInfo;
            }
            return null;
        }
    }
}