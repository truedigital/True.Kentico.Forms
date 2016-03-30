using System.Collections.Generic;
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
                    IsRequired = true, Label = "First name", Type = ControlType.TextBox, Name = "FirstName"
                },
                new Control
                {
                    IsRequired = true, Label = "Surname", Type = ControlType.TextBox, Name = "Surname"
                },
                new Control
                {
                    IsRequired = true, Label = "Email address", Type = ControlType.Email, Name = "EmailAddress",
                    Validation = new List<IControlValidation>
                    {
                        new ControlValidation { HasValue = true, ValidationType = ValidationType.Email, ValidationRule = "email", ValidationErrorMessage = "Please put a valid email address"}
                    }
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