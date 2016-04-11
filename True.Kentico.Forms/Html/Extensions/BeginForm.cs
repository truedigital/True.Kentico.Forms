using System.Web;
using System.Web.Mvc;
using True.Kentico.Forms.Forms.FormParts;

namespace True.Kentico.Forms.Html.Extensions
{
    public static partial class KenticoFormHelperExtensions
    {
        public static IHtmlString BeginForm(this KenticoForm html, string action, string controllerName, string formName, ISubmissionOptions options)
        {
            return BeginForm(html, action, controllerName, formName, options, "post", "block", true, false);
        }

        public static IHtmlString BeginForm(this KenticoForm html, string action, string controllerName, string formName, ISubmissionOptions options, string dataLayout) 
        {
            return BeginForm(html, action, controllerName, formName, options, "post", dataLayout, true, false);
        }

        public static IHtmlString BeginForm(this KenticoForm html, string action, string controllerName, string formName, ISubmissionOptions options, string method, string dataLayout) 
        {
            return BeginForm(html, action, controllerName, formName, options, method, dataLayout, true, false);
        }

        public static IHtmlString BeginForm(this KenticoForm html, string action, string controllerName, string formName, ISubmissionOptions options, string method, string dataLayout, bool validate) 
        {
            return BeginForm(html, action, controllerName, formName, options, method, dataLayout, validate, false);
        }

        public static IHtmlString BeginForm(this KenticoForm html, string action, string controllerName, string formName, ISubmissionOptions options, string method, string dataLayout, bool validate, bool summary) 
        {
            var submitData = "data-submit-";
            if (!string.IsNullOrEmpty(options.RedirectUrl)) submitData += $"url=\"{options.RedirectUrl}\" ";
            if (!string.IsNullOrEmpty(options.DisplayText)) submitData += $"text=\"{options.DisplayText}\" ";
            if (options.ClearAfterSave) submitData += $"reset=\"{options.ClearAfterSave}\" ";

            return MvcHtmlString.Create($"<form action=\"/{controllerName}/{action}\" " +
                                                $"method=\"{method}\" " +
                                                "class=\"form form--kentico\" " +
                                                submitData +
                                                $"{(validate ? " data-validate" : string.Empty)}{(summary ? " " + "data-summary" : string.Empty)} " +
                                                $"data-layout=\"{dataLayout}\">" +
                                        $"<input type=\"hidden\" name=\"formname\" value=\"{formName}\" /> ");
        }

        public static IHtmlString EndForm(this KenticoForm html)
        {
            return MvcHtmlString.Create("</form>");
        }
    }
}
