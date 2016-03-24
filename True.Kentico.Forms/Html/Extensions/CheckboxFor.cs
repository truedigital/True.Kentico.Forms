using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using True.Kentico.Forms.Html.ExtraAttributes;

namespace True.Kentico.Forms.Html.Extensions
{
	public static partial class KenticoFormHelperExtensions
	{
		public static IHtmlString CheckboxFor<TModel, TProperty>(this KenticoForm<TModel> html, Expression<Func<TModel, TProperty>> expression)
		{
			var item = (MemberExpression)expression.Body;
			var id = item.Member.Name;

			var dispAttr = GetAttribute<DisplayAttribute>(item);
			var displayName = dispAttr != null ? dispAttr.Name : item.Member.Name;

			var reqAttr = GetAttribute<RequiredAttribute>(item);
			var helpTextAttr = GetAttribute<HelpTextAttribute>(item);

			var div = new MultiLevelTag("div");
			div.AddCssClass("form-inner");

			var input = new MultiLevelTag("input");
			input.Attributes.Add("id", $"{id}");
			input.Attributes.Add("name", id);
			input.Attributes.Add("type", "checkbox");
			if (reqAttr != null)
				input.Attributes.Add("required", null);

			var label = new MultiLevelTag("label");
			label.Attributes.Add("for", $"{id}");
			label.SetInnerText(displayName);

			var radioDiv = new MultiLevelTag("div");
			radioDiv.AddCssClass("form-radio");

			radioDiv.Add(input);
			radioDiv.Add(label);

			div.Add(radioDiv);

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
