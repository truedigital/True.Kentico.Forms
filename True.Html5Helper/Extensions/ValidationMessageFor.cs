using System;
using System.Linq.Expressions;

namespace True.Html5Helper.Extensions
{
	public static partial class Html5HelperExtensions
	{
		public static string ValidationMessageFor<TModel, TProperty>(this Html5<TModel> html, Expression<Func<TModel, TProperty>> expression)
		{
			return "test";
		}
	}
}
