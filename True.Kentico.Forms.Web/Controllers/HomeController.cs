using System.Collections.Generic;
using System.Web.Mvc;
using True.Kentico.Forms.Forms;
using True.Kentico.Forms.Forms.FormParts;

namespace True.Kentico.Forms.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
            
        }


        public ActionResult KenticoForm()
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
                        new ControlValidation { HasValue = true, ValidationRule = "minlength", ValidationValue = "3", ValidationErrorMessage = "too short"},
                        new ControlValidation { HasValue = true, ValidationRule = "maxlength", ValidationValue = "5", ValidationErrorMessage = "too long"}
                    }
                },
                new Control
                {
                    IsRequired = true, Label = "Surname", Type = ControlType.TextBox, Name = "Surname",
                    Validation = new List<IControlValidation>
                    {
                        new ControlValidation { HasValue = true, ValidationRule = "maxlength", ValidationValue = "9", ValidationErrorMessage = "too long"}
                    }
                },
                new Control
                {
                    IsRequired = true, Label = "Email address", Type = ControlType.Email, Name = "EmailAddress",
                    ExplanationText = "explanation about putting your email in this field",
                    Tooltip = "a tool tip saying what is an email",
                    Validation = new List<IControlValidation>
                    {
                        new ControlValidation { HasValue = true, ValidationRule = "email", ValidationErrorMessage = "not valid email"}
                    }
                },
                new Control
                {
                    IsRequired = true, Label = "This is a checkbox", Type = ControlType.CheckBox, Name = "CheckYes",
                    ExplanationText = "explanation about this field",
                    Tooltip = "a tool tip saying what goes here",
                    DefaultValue = "Yes",
                    DefaultValues = new Dictionary<string,bool> { {"Yes", false}}
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
                    DefaultValues = new Dictionary<string, bool> { { "Daily", false }, { "Weekly", false }, { "Monthly", false } }
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

            var model = new Form
            {
                Name = "my form",
                SubmitText = "Submit",
                SubmissionOptions = submissionOptions,
                Controls = controls
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult FormResult(Form form)
        {
            return new EmptyResult();
        }
    }
}