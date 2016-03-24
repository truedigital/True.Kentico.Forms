using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using True.Kentico.Forms.Html.ExtraAttributes;

namespace True.Kentico.Forms.Html.Extensions
{
	public static partial class KenticoFormHelperExtensions
	{
		public static IHtmlString RadioButtonFor<TModel, TProperty>(this KenticoForm<TModel> html, Expression<Func<TModel, TProperty>> expression) where TProperty : List<KeyValuePair<int, string>>
		{
			var item = (MemberExpression)expression.Body;
			var id = item.Member.Name;

			var reqAttr = GetAttribute<RequiredAttribute>(item);
			var helpTextAttr = GetAttribute<HelpTextAttribute>(item);

			var div = new MultiLevelTag("div");
			div.AddCssClass("form-inner");

			var items = (List<KeyValuePair<int, string>>)GetValue(expression, html.Model);

			var count = 1;
			foreach (var innerItem in items) {
				var input = new MultiLevelTag("input");
				input.Attributes.Add("id", $"{id}_{count}");
				input.Attributes.Add("value", $"{id}_{count}");
				input.Attributes.Add("name", id);
				input.Attributes.Add("type", "radio");
				if (count == 1 && reqAttr != null)
					input.Attributes.Add("required", null);

				var label = new MultiLevelTag("label");
				label.Attributes.Add("for", $"{id}_{count}");
				label.SetInnerText(innerItem.Value);

				var radioDiv = new MultiLevelTag("div");
				radioDiv.AddCssClass("form-radio");

				radioDiv.Add(input);
				radioDiv.Add(label);

				div.Add(radioDiv);
				count++;
			}

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
