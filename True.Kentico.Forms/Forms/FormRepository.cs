using System;
using System.Linq;
using System.Text;
using System.Web;
using CMS.Core;
using CMS.DataEngine;
using CMS.FormEngine;
using CMS.IO;
using CMS.OnlineForms;
using CMS.SiteProvider;
using True.Kentico.Forms.Forms.FormParts;
using Stream = System.IO.Stream;

namespace True.Kentico.Forms.Forms
{
    public class FormRepository : IFormRepository
    {
        private readonly IFormFactory _formFactory;

        public FormRepository()
        {
            _formFactory = new FormFactory(new ControlFactory.ControlFactory());
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

        public void Submit(IForm form)
        {
            try
            {
                var formInfo = BizFormInfoProvider.GetBizFormInfo(form.Name, SiteContext.CurrentSiteID);
                var dataClassInfo = DataClassInfoProvider.GetDataClassInfo(formInfo.FormClassID);
                var item = new BizFormItem(dataClassInfo.ClassName);

                SetFormValues(form, item);

                item.SetValue("FormInserted", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                item.SetValue("FormUpdated", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                BizFormItemProvider.SetItem(item);
                BizFormInfoProvider.RefreshDataCount(formInfo.FormName, formInfo.FormSiteID);
            }
            catch (Exception ex)
            {
                throw new Exception("There was a problem saving the form. Please contact our support team.", ex);
            }
        }

        private void SetFormValues(IForm form, BizFormItem item)
        {
            foreach (var control in form.Controls)
            {
                if (control is IFileControl)
                {
                    HandleFileControl(control, item);
                }
                else
                {
                    item.SetValue(control.Name, control.SubmittedValue);
                }
            }
        }

        private void HandleFileControl(IControl control, BizFormItem item)
        {
            var fileControl = control as IFileControl;
            if (string.IsNullOrWhiteSpace(fileControl?.SubmittedValue) | fileControl?.SubmittedData == null) return;

            var fileNameMask = Guid.NewGuid();
            var extension = fileControl.SubmittedValue.Substring(fileControl.SubmittedValue.LastIndexOf(".", StringComparison.Ordinal));
            item.SetValue(fileControl.Name, $"{fileNameMask}{extension}/{fileControl.SubmittedValue}");

            SaveFile($"{fileNameMask}{extension}", fileControl.SubmittedData);
        }

        private void SaveFile(string maskedFileName, Stream inputStream)
        {
            // Path to BizForm files in file system.
            var filesFolderPath = FormHelper.GetBizFormFilesFolderPath(SiteContext.CurrentSiteName);

            // Get file size and path
            var filePath = filesFolderPath + maskedFileName;

            // Ensure disk path
            DirectoryHelper.EnsureDiskPath(filePath, HttpRuntime.AppDomainAppPath);

            StorageHelper.SaveFileToDisk(filePath, new BinaryData(inputStream));
        }
    }
}