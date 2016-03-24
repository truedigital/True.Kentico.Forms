using System.Web;
using System.Web.Mvc;

namespace True.Html5Helper.Extensions
{
	public static partial class Html5HelperExtensions
	{
		public static IHtmlString BeginForm<TModel>(this Html5<TModel> html, string method = "post", string action = "", string dataLayout="inline", bool validate = true, bool summary=true)
		{
			return MvcHtmlString.Create($"<form method=\"{method}\" action=\"{action}\" class=\"form\"{(validate ? " data-validate" : string.Empty)}{(summary ? " data-summary" : string.Empty)} data-layout=\"{dataLayout}\">");
    }

		public static IHtmlString EndForm<TModel>(this Html5<TModel> html)
		{
			return MvcHtmlString.Create("</form>");
		}
	}
}
