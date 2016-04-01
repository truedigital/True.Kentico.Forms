using System.Net;
using System.Web;
using System.Web.Mvc;
using True.Kentico.Forms.Forms.FormParts;

namespace True.Kentico.Forms.Html.Extensions
{
    public static partial class KenticoFormHelperExtensions
    {
        public static IHtmlString BeginForm<TModel>(this KenticoForm<TModel> html, string action, string controllerName, ISubmissionOptions options) where TModel : IForm
        {
            return BeginForm<TModel>(html, action, controllerName, options, "post", "block", true, false);
        }

        public static IHtmlString BeginForm<TModel>(this KenticoForm<TModel> html, string action, string controllerName, ISubmissionOptions options, string dataLayout) where TModel : IForm
        {
            return BeginForm<TModel>(html, action, controllerName, options, "post", dataLayout, true, false);
        }

        public static IHtmlString BeginForm<TModel>(this KenticoForm<TModel> html, string action, string controllerName, ISubmissionOptions options, string method, string dataLayout) where TModel : IForm
        {
            return BeginForm<TModel>(html, action, controllerName, options, method, dataLayout, true, false);
        }

        public static IHtmlString BeginForm<TModel>(this KenticoForm<TModel> html, string action, string controllerName, ISubmissionOptions options, string method, string dataLayout, bool validate) where TModel : IForm
        {
            return BeginForm<TModel>(html, action, controllerName, options, method, dataLayout, validate, false);
        }

        public static IHtmlString BeginForm<TModel>(this KenticoForm<TModel> html, string action, string controllerName, ISubmissionOptions options, string method, string dataLayout, bool validate, bool summary) where TModel : IForm
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
                                        $"<input type=\"hidden\" name=\"formname\" value=\"{html.Model.Name}\" /> ");
        }

        public static IHtmlString EndForm<TModel>(this KenticoForm<TModel> html) where TModel : IForm
        {
            return MvcHtmlString.Create("</form>");
        }
    }
}
