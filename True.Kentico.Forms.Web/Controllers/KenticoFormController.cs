using System;
using System.Net;
using System.Web.Mvc;
using True.Kentico.Forms.Forms;
using True.Kentico.Forms.Forms.FormParts;

namespace True.Kentico.Forms.Web.Controllers
{
    public class KenticoFormController : Controller
    {
        public class FormController : Controller
        {
            private readonly FormRepository _formRepository;

            public FormController(FormRepository formRepository)
            {
                _formRepository = formRepository;
            }

            /// <summary>
            /// Default controller action
            /// </summary>
            /// <returns>Work view ActionResult</returns>
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
}