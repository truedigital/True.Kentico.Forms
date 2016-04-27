using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using True.Kentico.Forms.Forms.FormParts;
using True.Kentico.Forms.Forms.Validation;

namespace True.Kentico.Forms.Web.Models
{
    public class LongForm : IForm
    {
        public string Name { get; set; }
        public string SubmitText { get; set; }
        public IList<IControl> Controls { get; set; }
        public IAutoresponder Autoresponder { get; set; }
        public INotification Notification { get; set; }
        public ISubmissionOptions SubmissionOptions { get; set; }
        public bool IsValid => Controls.All(x => x.IsValid());
        public IList<string> ValidationErrors => Controls.SelectMany(ctrl => ctrl.ValidationErrors).ToList();

        public IControl Find(string name)
        {
            return Controls.FirstOrDefault(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public LongForm(string name)
        {
            var controls = new List<IControl>
            {
                new Control
                {
                    IsRequired = true, Label = "Upload an image", Type = ControlType.UploadFile, Name = "ImageUpload",
                    ExplanationText = "explanation about this field",
                    Tooltip = "only image file extensions for now"
                },
                new Control
                {
                    IsRequired = true, Label = "First name", Type = ControlType.TextBox, Name = "FirstName",
                    ExplanationText = "explanation about this field",
                    Tooltip = "a tool tip saying what goes here",
                    Validation = new List<IControlValidation>
                    {
                        new MinimumLengthControlValidation { HasValue = true, ValidationRule = "minlength", ValidationValue = "3", ValidationErrorMessage = "too short"},
                        new MaximumLengthControlValidation { HasValue = true, ValidationRule = "maxlength", ValidationValue = "5", ValidationErrorMessage = "too long"}
                    }
                },
                new Control
                {
                    IsRequired = true, Label = "Enter a Uk Postcode", Type = ControlType.TextBox, Name = "UkPostcode",
                    ExplanationText = "explanation about this field",
                    Tooltip = "a tool tip saying what goes here",
                    Validation = new List<IControlValidation>
                    {
                        new RegularExpressionControlValidation { HasValue = true, ValidationRule = "regular-expression", ValidationValue = "(GIR ?0AA|[A-PR-UWYZ]([0-9]{1,2}|([A-HK-Y][0-9]([0-9ABEHMNPRV-Y])?)|[0-9][A-HJKPS-UW]) ?[0-9][ABD-HJLNP-UW-Z]{2})$", ValidationErrorMessage = "not right"}
                    }
                },
                new Control
                {
                    IsRequired = true, Label = "Surname", Type = ControlType.TextBox, Name = "Surname",
                    Validation = new List<IControlValidation>
                    {
                        new MaximumLengthControlValidation { HasValue = true, ValidationRule = "maxlength", ValidationValue = "9", ValidationErrorMessage = "too long"}
                    }
                },
                new Control
                {
                    IsRequired = true, Label = "Email address", Type = ControlType.Email, Name = "EmailAddress",
                    ExplanationText = "explanation about putting your email in this field",
                    Tooltip = "a tool tip saying what is an email",
                    Validation = new List<IControlValidation>
                    {
                        new EmailControlValidation { HasValue = true, ValidationRule = "email", ValidationErrorMessage = "not valid email"}
                    }
                },
                new Control
                {
                    IsRequired = true, Label = "This is a checkbox", Type = ControlType.CheckBox, Name = "CheckYes",
                    ExplanationText = "explanation about this field",
                    Tooltip = "a tool tip saying what goes here",
                    DefaultValue = "Yes",
                    DefaultValues = new Dictionary<string,bool> { {"Yes", true}}
                },
                new Control
                {
                    IsRequired = true,
                    ExplanationText = "explanation about this field",
                    Tooltip = "a tool tip saying what goes here",
                    Label = "Radio button options",
                    Type = ControlType.RadioButton,
                    Name = "Shop",
                    DefaultValue = "Daily\r\nWeekly\r\nFornightly\r\nMonthly",
                    DefaultValues = new Dictionary<string, bool> { { "Daily", true }, { "Weekly", false }, { "Monthly", false } }
                },
                new Control
                {
                    IsRequired = true,
                    ExplanationText = "explanation about this field",
                    Tooltip = "a tool tip saying what goes here",
                    Label = "Multiple choices",
                    Type = ControlType.MultipleChoice,
                    Name = "Where",
                    DefaultValue = "Buses|Radio",
                    DefaultValues = new Dictionary<string, bool> { { "Buses", true }, { "Posters", false }, { "Heart Radio", true } }
                },
                new Control
                {
                    IsRequired = true,
                    ExplanationText = "explanation about this field",
                    Tooltip = "a tool tip saying what goes here",
                    Label = "Drop Down List",
                    Type = ControlType.DropDownList,
                    Name = "Show",
                    DefaultValue = " \r\nYes\r\nNo",
                    DefaultValues = new Dictionary<string, bool> { { " ", false }, { "Yes", true }, { "No", false } }
                },
                new Control
                {
                    IsRequired = true,
                    ExplanationText = "explanation about this field",
                    Tooltip = "a tool tip saying what goes here",
                    Label = "Radio button opt in",
                    Type = ControlType.RadioButton,
                    Name = "Optin",
                    DefaultValue = "Yes",
                    DefaultValues = new Dictionary<string, bool> { { "Yes", true }, { "No", true } }
                }
            };

            var submissionOptions = new SubmissionOptions
            {
                DisplayText = "thanks for submitting"
            };

            Name = name;
            SubmitText = "Submit";
            SubmissionOptions = submissionOptions;
            Controls = controls;
        }
    }

    public class ShortForm : IForm
    {
        public string Name { get; set; }
        public string SubmitText { get; set; }
        public IList<IControl> Controls { get; set; }
        public IAutoresponder Autoresponder { get; set; }
        public INotification Notification { get; set; }
        public ISubmissionOptions SubmissionOptions { get; set; }
        public bool IsValid => Controls.All(x => x.IsValid());
        public IList<string> ValidationErrors => Controls.SelectMany(ctrl => ctrl.ValidationErrors).ToList();

        public IControl Find(string name)
        {
            return Controls.FirstOrDefault(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public ShortForm(string name)
        {
            var controls = new List<IControl>
            {
                new Control
                {
                    IsRequired = true, Label = "First name", Type = ControlType.TextBox, Name = "FirstName",
                    ExplanationText = "explanation about this field",
                    Tooltip = "a tool tip saying what goes here",
                    Validation = new List<IControlValidation>
                    {
                        new MinimumLengthControlValidation { HasValue = true, ValidationRule = "minlength", ValidationValue = "3", ValidationErrorMessage = "too short"},
                        new MaximumLengthControlValidation { HasValue = true, ValidationRule = "maxlength", ValidationValue = "5", ValidationErrorMessage = "too long"}
                    }
                },
                new Control
                {
                    IsRequired = true, Label = "Email address", Type = ControlType.Email, Name = "EmailAddress",
                    ExplanationText = "explanation about putting your email in this field",
                    Tooltip = "a tool tip saying what is an email",
                    Validation = new List<IControlValidation>
                    {
                        new EmailControlValidation { HasValue = true, ValidationRule = "email", ValidationErrorMessage = "not valid email"}
                    }
                },
                //new Control
                //{
                //    IsRequired = true, Label = "Pick a date", Type = ControlType.Calendar, Name = "DatePick"
                //},
                new Control
                {
                    IsRequired = true, Label = "Enter a Uk Postcode", Type = ControlType.TextBox, Name = "UkPostcode",
                    ExplanationText = "explanation about this field",
                    Tooltip = "a tool tip saying what goes here",
                    Validation = new List<IControlValidation>
                    {
                        new RegularExpressionControlValidation { HasValue = true, ValidationRule = "regular-expression", ValidationValue = "(GIR ?0AA|[A-PR-UWYZ]([0-9]{1,2}|([A-HK-Y][0-9]([0-9ABEHMNPRV-Y])?)|[0-9][A-HJKPS-UW]) ?[0-9][ABD-HJLNP-UW-Z]{2})$", ValidationErrorMessage = "not right"}
                    }
                }
            };

            var submissionOptions = new SubmissionOptions
            {
                DisplayText = "thanks for submitting"
            };

            Name = name;
            SubmitText = "Submit";
            SubmissionOptions = submissionOptions;
            Controls = controls;
        }
    }
}