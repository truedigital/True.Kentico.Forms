﻿using System.Collections.Generic;
using System.Web.Mvc;
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
            var model = new Form();
            return View(model);
        }
    }
}