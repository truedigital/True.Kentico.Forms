using System;
using System.Linq.Expressions;

namespace True.Kentico.Forms.Html.Extensions
{
	public static partial class KenticoFormHelperExtensions
	{
		public static string ValidationMessageFor<TModel, TProperty>(this KenticoForm<TModel> html, Expression<Func<TModel, TProperty>> expression)
		{
			return "test";
		}
	}
}
