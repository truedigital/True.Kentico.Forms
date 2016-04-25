using System.Collections.Generic;
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

        public ActionResult KenticoForm()
        {
            return View("~/Views/KenticoForm/Index.cshtml", new LongForm("my-form"));
        }

        [HttpPost]
        public ActionResult FormResult(Form form)
        {
            return new EmptyResult();
        }
    }
}