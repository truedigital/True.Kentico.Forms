using System.Collections.Generic;
using System.Linq;
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
                    Validation = new List<IControlValidation>
                    {
                        new ControlValidation { HasValue = true, ValidationRule = "email", ValidationErrorMessage = "not valid email"}
                    }
                },
                new Control
                {
                    IsRequired = false, Label = "How often do you shop for fashion items online", Type = ControlType.RadioButton, Name = "Shop",
                    DefaultValue = "Daily\r\nWeekly\r\nFornightly\r\nMonthly"
                },
                new Control
                {
                    IsRequired = false, Label = "Where have you seen things", Type = ControlType.MultipleChoice, Name = "Where",
                    DefaultValue = "Buses\r\nPosters\r\nFacebook\r\nHeart Radio"
                },
                new Control
                {
                    IsRequired = false, Label = "Did you go to the fashion show", Type = ControlType.DropDownList, Name = "Show",
                    DefaultValue = "Please choose\r\nYes\r\nNo"
                },
                new Control
                {
                    IsRequired = false, Label = "Opt in", Type = ControlType.CheckBox, Name = "Optin"
                }
            };

            var model = new Form
            {
                Name = "my form",
                Controls = controls
            };

            return View(model);
        }
    }
}