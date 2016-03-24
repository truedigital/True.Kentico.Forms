using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using True.Html5Helper.ExtraAttributes;

namespace True.Html5Helper.Extensions
{
	public static partial class Html5HelperExtensions
	{
		public static IHtmlString RichTextEditorFor<TModel, TProperty>(this Html5<TModel> html, Expression<Func<TModel, TProperty>> expression)
		{
			var item = (MemberExpression)expression.Body;
			var id = item.Member.Name;

			var dispAttr = GetAttribute<DisplayAttribute>(item);
			var displayName = dispAttr != null ? dispAttr.Name : item.Member.Name;

			var reqAttr = GetAttribute<RequiredAttribute>(item);
			var helpTextAttr = GetAttribute<HelpTextAttribute>(item);

			var div = new MultiLevelTag("div");
			div.AddCssClass("form-inner");

			var rte = new MultiLevelTag("textarea");
			rte.Attributes.Add("id", id);
			rte.Attributes.Add("name", id);
			rte.AddCssClass("rich-text-editor");

			if (reqAttr != null) {
				rte.Attributes.Add("required", null);
				rte.Attributes.Add("data-msg-required", $"{displayName} is required");
			}

			div.Add(rte);

			if (helpTextAttr != null) {
				var helpTextDiv = new MultiLevelTag("div");
				helpTextDiv.AddCssClass("form-help");
				helpTextDiv.InnerHtml = helpTextAttr.HelpText;
				div.Add(helpTextDiv);
			}

			return MvcHtmlString.Create(div.ToString());
		}
	}
}
