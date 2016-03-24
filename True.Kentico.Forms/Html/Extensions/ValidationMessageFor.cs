using System;
using System.Linq.Expressions;

namespace True.Kentico.Forms.Html.Extensions
{
	public static partial class Html5HelperExtensions
	{
		public static string ValidationMessageFor<TModel, TProperty>(this Html5<TModel> html, Expression<Func<TModel, TProperty>> expression)
		{
			return "test";
		}
	}
}
