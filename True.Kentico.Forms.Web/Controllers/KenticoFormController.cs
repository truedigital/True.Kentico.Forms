using System;
using System.Net;
using System.Web.Mvc;
using True.Kentico.Forms.Forms;
using True.Kentico.Forms.Forms.FormParts;
using True.Kentico.Forms.Web.Models;

namespace True.Kentico.Forms.Web.Controllers
{
    public class KenticoFormController : Controller
    {
        private readonly IFormRepository _formRepository;

        public KenticoFormController() : this(new FormRepository())
        {
        }

        public KenticoFormController(IFormRepository formRepository)
        {
            _formRepository = formRepository;
        }

        public ActionResult Index()
        {
            var form = _formRepository.GetForm("");
            return View(form);
        }

        public ActionResult Example()
        {
            //var form = _formRepository.GetForm("myform");
            return View("~/Views/KenticoForm/Index.cshtml", new ExampleForm("dave"));
        }

        /// <summary>
        /// The controller action that handles the form submission post event.
        /// </summary>
        /// <returns>200 status, error in Json format or 500 status</returns>
        [HttpPost]
        public ActionResult Save(IForm form)
        {
            try
            {
                _formRepository.Submit(form);
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            catch (InvalidOperationException ex)
            {
                return Json(ex.Message);
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }
    }
}