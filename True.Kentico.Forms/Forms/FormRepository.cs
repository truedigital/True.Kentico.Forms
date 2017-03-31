using System;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using CMS.Core;
using CMS.DataEngine;
using CMS.EmailEngine;
using CMS.FormEngine;
using CMS.Helpers;
using CMS.IO;
using CMS.OnlineForms;
using CMS.SiteProvider;
using True.Kentico.Forms.Forms.FormParts;
using Stream = System.IO.Stream;
using True.Kentico.Forms.Forms.Emailer;
using System.Collections.Generic;
using True.Kentico.Forms.Forms.Data;

namespace True.Kentico.Forms.Forms
{
    public class FormRepository : IFormRepository
    {
        private readonly IFormFactory _formFactory;
        private readonly IFormValueEmailParser _emailParser;

        public FormRepository()
        {
            _formFactory = new FormFactory(new ControlFactory.ControlFactory());
            _emailParser = new FormValueEmailParser();
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

        public List<FormEntry> GetFormEntries(string formName)
        {
            List<FormEntry> entries = new List<FormEntry>();
            BizFormInfo formObject = BizFormInfoProvider.GetBizFormInfo(formName, SiteContext.CurrentSiteID);
            if (formObject == null)
                throw new InvalidOperationException("The requested checkin form does not exist.");
            // Gets the class name of the form
            DataClassInfo formClass = DataClassInfoProvider.GetDataClassInfo(formObject.FormClassID);
            string className = formClass.ClassName;

            // Loads the form's data
            ObjectQuery<BizFormItem> data = BizFormItemProvider.GetItems(className);

            // Checks whether the form contains any records
            if (!DataHelper.DataSourceIsEmpty(data))
            {
                // Loops through the form's data records
                foreach (BizFormItem item in data)
                {
                    FormEntry entry = new FormEntry();
                    entry.ID = item.ItemID;

                    foreach (var columnName in item.ColumnNames)
                    {
                        entry.FormValues.Add(columnName.ToLower(), item.GetStringValue(columnName, ""));
                    }
                    entries.Add(entry);
                }
            }
            return entries;
        }

        public void InsertFormEntry(string formName, FormEntry entry)
        {
            BizFormInfo formObject = BizFormInfoProvider.GetBizFormInfo(formName, SiteContext.CurrentSiteID);
            if (formObject == null)
                throw new InvalidOperationException("The requested checkin form does not exist.");
            // Gets the class name of the 'ContactUs' form
            DataClassInfo formClass = DataClassInfoProvider.GetDataClassInfo(formObject.FormClassID);
            string className = formClass.ClassName;

            BizFormItem item = BizFormItem.New(className);

            foreach (var formValue in entry.FormValues)
            {
                item.SetValue(item.ColumnNames.Find(t => t.ToLower() == formValue.Key), formValue.Value);
            }

            item.Insert();
        }

        public void UpdateFormEntry(string formName, int itemID, string fieldToUpdate, object newValue)
        {
            BizFormInfo formObject = BizFormInfoProvider.GetBizFormInfo(formName, SiteContext.CurrentSiteID);
            if (formObject == null)
                throw new InvalidOperationException("The requested checkin form does not exist.");
            // Gets the class name of the form
            DataClassInfo formClass = DataClassInfoProvider.GetDataClassInfo(formObject.FormClassID);
            string className = formClass.ClassName;

            BizFormItem item = BizFormItemProvider.GetItem(itemID, className);

            item.SetValue(item.ColumnNames.Find(t => t.ToLower() == fieldToUpdate), newValue);
            item.SubmitChanges(false);
        }

        public void Submit(IForm form)
        {
            try
            {
                var formInfo = BizFormInfoProvider.GetBizFormInfo(form.Name, SiteContext.CurrentSiteID);
                if (formInfo == null)
                    throw new InvalidOperationException("The requested checkin form does not exist.");
                var dataClassInfo = DataClassInfoProvider.GetDataClassInfo(formInfo.FormClassID);
                var item = new BizFormItem(dataClassInfo.ClassName);

                SetFormValues(form, item);

                item.SetValue("FormInserted", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                item.SetValue("FormUpdated", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                BizFormItemProvider.SetItem(item);
                BizFormInfoProvider.RefreshDataCount(formInfo.FormName, formInfo.FormSiteID);

                if (form.Notification != null)
                    SendNotificationEmail(formInfo, form, item);

                if (!String.IsNullOrEmpty(form.Autoresponder?.Sender))
                    SendAcknowledgementEmail(formInfo, item, form.Controls);
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

            SaveFile(fileNameMask.ToString(), extension, fileControl.SubmittedData);
        }

        private void SaveFile(string fileName, string extension, Stream inputStream)
        {
            // Path to BizForm files in file system.
            var siteName = SiteContext.CurrentSiteName;
            var filesFolderPath = FormHelper.GetBizFormFilesFolderPath(siteName);

            // Get file size and path
            var filePath = filesFolderPath + $"{fileName}{extension}";

            // Ensure disk path
            DirectoryHelper.EnsureDiskPath(filePath, HttpRuntime.AppDomainAppPath);

            if (ImageHelper.IsImage(extension))
            {
                byte[] imageBinary = ReadFully(inputStream);

                StorageHelper.SaveFileToDisk(filePath, imageBinary);
            }
            else
            {
                StreamWrapper stream = StreamWrapper.New(inputStream);
                StorageHelper.SaveFileToDisk(filePath, stream, false);
            }

            // Check synchronization max. file size
            //if (WebFarmHelper.WebFarmEnabled)
            //{
            //    StreamWrapper stream = StreamWrapper.New(inputStream);
            //    WebFarmHelper.CreateTask(FormTaskType.UpdateBizFormFile, "updatebizformfile", siteName + "|" + fileName, stream);
            //    //WebFarmHelper.CreateTask(FormTaskType.UpdateBizFormFile, filePath, stream.ToString(), "updatebizformfile", SiteContext.CurrentSiteName, fileName);
            //}
        }

        public static byte[] ReadFully(System.IO.Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }

        private void SendNotificationEmail(BizFormInfo formInfo, IForm form, BizFormItem item)
        {
            AddSpecialFormControls(formInfo, item, form.Controls);

            EmailMessage em = new EmailMessage();
            em.EmailFormat = EmailFormatEnum.Html;
            em.From = formInfo.FormSendFromEmail;
            em.Recipients = formInfo.FormSendToEmail;
            em.Subject = formInfo.FormEmailSubject;

            foreach (var source in form.Controls.Where(t => t.Type == ControlType.UploadFile))
            {
                var fileControl = (source as IFileControl);
                if (fileControl?.SubmittedValue != null)
                {
                    var extension =
                        fileControl.SubmittedValue.Substring(fileControl.SubmittedValue.LastIndexOf(".",
                            StringComparison.Ordinal));

                    fileControl.SubmittedData.Position = 0;

                    em.Attachments.Add(new Attachment(fileControl.SubmittedData, fileControl.Name + extension));
                }
            }

            if (string.IsNullOrWhiteSpace(form?.Notification?.Template))
            {
                var html = "";
                foreach (var fieldInfo in form.Controls)
                {
                    html += $"<tr><td>{fieldInfo.Label}</td><td>{fieldInfo.SubmittedValue?.Replace("\r\n", "<br />")}</td></tr>";
                }
                em.Body = "<table cellpadding=\"10\">" + html + "</table>";
            }
            else
            {
                em.Body = _emailParser.Parse(form.Notification?.Template, form.Controls);
            }

            EmailSender.SendEmail(em);
        }

        private void SendAcknowledgementEmail(BizFormInfo formInfo, BizFormItem item, IList<IControl> controls)
        {
            AddSpecialFormControls(formInfo, item, controls);

            EmailMessage em = new EmailMessage
            {
                EmailFormat = EmailFormatEnum.Html,
                From = formInfo.FormConfirmationSendFromEmail,
                Recipients = item.GetStringValue(formInfo.FormConfirmationEmailField, String.Empty),
                Subject = formInfo.FormConfirmationEmailSubject,
                Body = _emailParser.Parse(formInfo.FormConfirmationTemplate, controls)
            };

            EmailSender.SendEmail(em);
        }

        private void AddSpecialFormControls(BizFormInfo formInfo, BizFormItem item, IList<IControl> controls)
        {
            // these special fields may not be in the controls list, so add their values manually, check first though
            if (controls.FirstOrDefault(ctrl => ctrl.Name == "FormInserted") == null)
                controls.Add(new Control { Name = "FormInserted", Label = "Form Submission Date", SubmittedValue = item.FormInserted.ToString("U") });
            if (controls.FirstOrDefault(ctrl => ctrl.Name == "FormUpdated") == null)
                controls.Add(new Control { Name = "FormUpdated", Label = "Form Update Date", SubmittedValue = item.FormUpdated.ToString("U") });
            if (controls.FirstOrDefault(ctrl => ctrl.Name == $"{formInfo.FormName}ID") == null)
                controls.Add(new Control { Name = $"{formInfo.FormName}ID", Label = formInfo.FormDisplayName, SubmittedValue = formInfo.FormDisplayName });
        }
    }
}