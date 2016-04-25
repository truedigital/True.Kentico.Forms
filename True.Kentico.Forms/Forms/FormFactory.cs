using CMS.Base;
using CMS.OnlineForms;
using True.Kentico.Forms.Forms.ControlFactory;
using True.Kentico.Forms.Forms.FormParts;

namespace True.Kentico.Forms.Forms
{
    /// <summary>
    /// class used to convert a bizformInfo object to an Iform object
    /// </summary>
    public class FormFactory : IFormFactory
    {
        private readonly IControlFactory _controlFactory;

        public FormFactory(IControlFactory controlFactory)
        {
            _controlFactory = controlFactory;
        }

        public IForm Create(BizFormInfo info)
        {
            if (info == null)
                return new Form();

            var autoresponder = new Autoresponder
            {
                Sender = info.FormConfirmationSendFromEmail,
                Subject = info.FormConfirmationEmailSubject,
                Template = info.FormConfirmationTemplate
            };

            var notification = new Notification
            {
                Sender = info.FormSendFromEmail,
                Recipients = info.FormSendToEmail,
                Subject = info.FormEmailSubject,
                Template = info.FormEmailTemplate,
                AttachUploadedDocuments = info.FormEmailAttachUploadedDocs
            };

            var submissionOptions = new SubmissionOptions
            {
                DisplayText = info.FormDisplayText,
                ClearAfterSave = info.FormClearAfterSave,
                RedirectUrl = info.FormRedirectToUrl
            };

            var form = new Form
            {
                Name = info.FormName,
                SubmitText = !string.IsNullOrEmpty(info.FormSubmitButtonText) ? info.FormSubmitButtonText : "Save",
                Autoresponder = autoresponder,
                Notification = notification,
                SubmissionOptions = submissionOptions
            };

            foreach (var controlInfo in info.Form.GetFields(true, false))
            {
                var control = _controlFactory.Create(controlInfo);
                if (control == null)
                    continue;

                form.Controls.Add(control);
            }

            return form;
        }
    }
}
