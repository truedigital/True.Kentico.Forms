using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrueMVCForms.Models;

namespace TrueMVCForms.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}

		public ActionResult Test()
		{
			var model = new TestModel {
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
	}
}