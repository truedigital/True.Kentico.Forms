using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using True.Html5Helper.ExtraAttributes;

namespace True.Html5Helper.Extensions
{
	public static partial class Html5HelperExtensions
	{
		public static IHtmlString ListBoxFor<TModel, TProperty>(this Html5<TModel> html, Expression<Func<TModel, TProperty>> expression) where TProperty : List<KeyValuePair<int, string>>
		{
			var item = (MemberExpression)expression.Body;
			var id = item.Member.Name;

			var dispAttr = GetAttribute<DisplayAttribute>(item);
			var displayName = dispAttr != null ? dispAttr.Name : item.Member.Name;

			var reqAttr = GetAttribute<RequiredAttribute>(item);
			var helpTextAttr = GetAttribute<HelpTextAttribute>(item);

			var div = new MultiLevelTag("div");
			div.AddCssClass("form-inner");

			var ddl = new MultiLevelTag("select");
			ddl.Attributes.Add("id", id);
			ddl.Attributes.Add("name", id);
			ddl.Attributes.Add("multiple", null);

			var items = (List<KeyValuePair<int, string>>)GetValue(expression, html.Model);

			foreach (var innerItem in items)
				ddl.Add(new MultiLevelTag("option") { InnerHtml = innerItem.Value });

			if (reqAttr != null) {
				ddl.Attributes.Add("required", null);
				ddl.Attributes.Add("data-msg-required", $"{displayName} is required");
			}

			div.Add(ddl);

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
