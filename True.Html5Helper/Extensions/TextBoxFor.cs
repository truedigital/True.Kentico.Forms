﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using True.Html5Helper.ExtraAttributes;

namespace True.Html5Helper.Extensions
{
	public static partial class Html5HelperExtensions
	{
		public static IHtmlString TextBoxFor<TModel, TProperty>(this Html5<TModel> html, Expression<Func<TModel, TProperty>> expression)
		{
			var item = (MemberExpression)expression.Body;
			var id = item.Member.Name;

			var dispAttr = GetAttribute<DisplayAttribute>(item);
			var displayName = dispAttr != null ? dispAttr.Name : item.Member.Name;

			var reqAttr = GetAttribute<RequiredAttribute>(item);
			var minLengthAttr = GetAttribute<MinLengthAttribute>(item);
			var helpTextAttr = GetAttribute<HelpTextAttribute>(item);

			var div = new MultiLevelTag("div");
			div.AddCssClass("form-inner");

			var input = new MultiLevelTag("input");
			input.Attributes.Add("id", id);
			input.Attributes.Add("name", id);
			input.Attributes.Add("type", "text");

			if (minLengthAttr != null)
				input.Attributes.Add("minlength", minLengthAttr.Length.ToString());

			if (reqAttr != null) {
				input.Attributes.Add("required", null);
				input.Attributes.Add("data-msg-required", $"{displayName} is required");
			}

			div.Add(input);

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
