using System.Web;
using System.Web.Mvc;

namespace True.Html5Helper.Extensions
{
	public static partial class Html5HelperExtensions
	{
		public static IHtmlString SubmitButton<TModel>(this Html5<TModel> html, string submitText)
		{
			var tag = new MultiLevelTag("button");
			tag.Attributes.Add("type", "submit");
			tag.Attributes.Add("data-submit", null);
			tag.AddCssClass("button");
			tag.SetInnerText(submitText);

			return MvcHtmlString.Create(tag.ToString());
		}
	}
}
