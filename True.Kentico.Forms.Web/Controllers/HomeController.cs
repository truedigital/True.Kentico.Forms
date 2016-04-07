﻿using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Web.Mvc;
using True.Kentico.Forms.Forms;
using True.Kentico.Forms.Forms.ControlValidationFactory;
using True.Kentico.Forms.Forms.FormParts;
using True.Kentico.Forms.Web.Models;

namespace True.Kentico.Forms.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Test()
        {
            var model = new TestModel
            {
                DropDownList = new List<KeyValuePair<int, string>> {
                    new KeyValuePair<int, string>(1, "Select dd option 1"),
                    new KeyValuePair<int, string>(1, "Select dd option 2"),
                    new KeyValuePair<int, string>(1, "Select dd option 3")
                },
                ListBox = new List<KeyValuePair<int, string>> {
                    new KeyValuePair<int, string>(1, "Select lb option 1"),
                    new KeyValuePair<int, string>(1, "Select lb option 2"),
                    new KeyValuePair<int, string>(1, "Select lb option 3")
                },
                RadioButtons = new List<KeyValuePair<int, string>> {
                    new KeyValuePair<int, string>(1, "Select rb option 1"),
                    new KeyValuePair<int, string>(1, "Select rb option 2"),
                    new KeyValuePair<int, string>(1, "Select rb option 3")
                },
                MultipleChoices = new List<KeyValuePair<int, string>> {
                    new KeyValuePair<int, string>(1, "Select mc option 1"),
                    new KeyValuePair<int, string>(1, "Select mc option 2"),
                    new KeyValuePair<int, string>(1, "Select mc option 3")
                }
            };
            return View(model);
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
                    DefaultValue = "Buses\r\nPosters\r\nFacebook\r\nHeart Radio",
                    DefaultValues = new Dictionary<string, bool> { { "Buses", true }, { "Posters", false }, { "Facebook", false } }
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