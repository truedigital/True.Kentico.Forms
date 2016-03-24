using System;
using CMS.DataEngine;
using CMS.OnlineForms;
using CMS.SiteProvider;

namespace True.KenticoForms.Forms
{
    public class FormRepository
    {
        public void Submit(IForm form)
        {
            var formInfo = BizFormInfoProvider.GetBizFormInfo(form.Name, SiteContext.CurrentSiteID);
            var dataClassInfo = DataClassInfoProvider.GetDataClassInfo(formInfo.FormClassID);

            var item = new BizFormItem(dataClassInfo.ClassName);

            foreach (var control in form.Controls)
            {
                item.SetValue(control.Name, control.SubmittedValue);
            }

            item.SetValue("FormInserted", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            item.SetValue("FormUpdated", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

            BizFormItemProvider.SetItem(item);
            BizFormInfoProvider.RefreshDataCount(formInfo.FormName, formInfo.FormSiteID);
        }
    }
}