using System;
using System.Linq;
using System.Net;
using System.Web;
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

        //public ActionResult Index()
        //{
        //    var form = _formRepository.GetForm("");
        //    return View(form);
        //}

        public ActionResult Example()
        {
            //var form = _formRepository.GetForm("myform");
            return View("~/Views/KenticoForm/Index.cshtml", new ShortForm("dave"));
        }

        /// <summary>
        /// The controller action that handles the form submission post event.
        /// </summary>
        /// <returns>200 status, error in Json format or 500 status</returns>
        [HttpPost]
        public ActionResult Save(IForm model)
        {
            try
            {
                if (model.IsValid)
                {
                    _formRepository.Submit(model);
                    return new HttpStatusCodeResult(HttpStatusCode.OK);
                }
                return Json(model.ValidationErrors);
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        public ActionResult Submit(ShortForm model)
        {
            try
            {
                if (model.IsValid)
                {
                    _formRepository.Submit(model);
                    return new HttpStatusCodeResult(HttpStatusCode.OK);
                }

                HttpContext.Response.StatusCode = 400;
                HttpContext.Response.StatusDescription = "Server validation failed";
                return Json(model.ValidationErrors);
            }
            catch (Exception ex)
            {
                HttpContext.Response.StatusDescription = ex.Message;
                HttpContext.Response.StatusCode = 500;
                return Json(ex);
            }
        }
    }
}