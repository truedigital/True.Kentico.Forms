using System.Net;
using System.Web;
using System.Web.Mvc;
using True.Kentico.Forms.Forms.FormParts;

namespace True.Kentico.Forms.Html.Extensions
{
    public static partial class KenticoFormHelperExtensions
    {
        public static IHtmlString BeginForm<TModel>(this KenticoForm<TModel> html, string action, string controllerName,
            ISubmissionOptions options, string method = "post", string dataLayout = "inline", bool validate = true,
            bool summary = false)
        {
            var submitData = "data-submit-";
            if (!string.IsNullOrEmpty(options.RedirectUrl)) submitData += $"url=\"{options.RedirectUrl}\" ";
            if (!string.IsNullOrEmpty(options.DisplayText)) submitData += $"text=\"{options.DisplayText}\" ";
            if (options.ClearAfterSave) submitData += $"reset=\"{options.ClearAfterSave}\" ";

            return MvcHtmlString.Create($"<form action=\"/{controllerName}/{action}\" " +
                                                $"method=\"{method}\" " +
                                                "class=\"form\" " +
                                                submitData +
                                                $"{(validate ? " data-validate" : string.Empty)}{(summary ? " " + "data-summary" : string.Empty)} " +
                                                $"data-layout=\"{dataLayout}\">");
        }

        public static IHtmlString EndForm<TModel>(this KenticoForm<TModel> html)
        {
            return MvcHtmlString.Create("</form>");
        }
    }
}
