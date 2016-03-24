﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace True.Html5Helper.Extensions
{
	public static partial class Html5HelperExtensions
	{
		private static T GetAttribute<T>(MemberExpression member)
		{
			return member.Member.GetCustomAttributes(true).OfType<T>().SingleOrDefault();
		}

		private static Func<T, object> GetValueGetter<T>(this PropertyInfo propertyInfo)
		{
			if (typeof(T) != propertyInfo.DeclaringType)
				throw new ArgumentException();

			var instance = Expression.Parameter(propertyInfo.DeclaringType, "i");
			var property = Expression.Property(instance, propertyInfo);
			var convert = Expression.TypeAs(property, typeof(object));
			return (Func<T, object>)Expression.Lambda(convert, instance).Compile();
		}

		private static TV GetValue<T, TV>(Expression<Func<T, TV>> expression, T model)
		{
			var compiledFunction = expression.Compile();
			var val = compiledFunction.Invoke(model);

			return val;
		}
	}
}
