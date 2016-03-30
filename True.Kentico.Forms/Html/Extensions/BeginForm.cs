using System.Web;
using System.Web.Mvc;

namespace True.Kentico.Forms.Html.Extensions
{
    public static partial class KenticoFormHelperExtensions
    {
        public static IHtmlString BeginForm<TModel>(this KenticoForm<TModel> html, string action = "", string method = "post", string dataLayout = "inline", bool validate = true, bool summary = true)
        {
            return MvcHtmlString.Create($"<form method=\"{method}\" action=\"{action}\" class=\"form\"{(validate ? " data-validate" : string.Empty)}{(summary ? " data-summary" : string.Empty)} data-layout=\"{dataLayout}\">");
        }

        public static IHtmlString EndForm<TModel>(this KenticoForm<TModel> html)
        {
            return MvcHtmlString.Create("</form>");
        }
    }
}
