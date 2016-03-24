using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace True.Kentico.Forms.Html.Extensions
{
	public static partial class Html5HelperExtensions
	{
		public static IHtmlString LabelFor<TModel, TProperty>(this Html5<TModel> html, Expression<Func<TModel, TProperty>> expression)
		{
			//var valueGetter = expression.Compile();
			//var model = valueGetter(html.Model);

			var item = (MemberExpression)expression.Body;
			var id = item.Member.Name;

			var reqAttr = GetAttribute<RequiredAttribute>(item);

			var required = string.Empty;
			if (reqAttr != null)
				required = " form-label--required";

			var dispAttr = GetAttribute<DisplayAttribute>(item);
			var output = dispAttr != null ? dispAttr.Name : item.Member.Name;

			var tb = new MultiLevelTag("label") { InnerHtml = $"{output}:" };
			tb.Attributes.Add("for", id);
			tb.Attributes.Add("class", $"form-label{required}");

			return MvcHtmlString.Create(tb.ToString());
		}
	}
}
