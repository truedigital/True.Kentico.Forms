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
        public static IHtmlString MultipleChoiceFor<TModel, TProperty>(this Html5<TModel> html, Expression<Func<TModel, TProperty>> expression) where TProperty : List<KeyValuePair<int, string>>
        {
            var item = (MemberExpression)expression.Body;
            var id = item.Member.Name;

            var helpTextAttr = GetAttribute<HelpTextAttribute>(item);

            var div = new MultiLevelTag("div");
            div.AddCssClass("form-inner");

            var items = (List<KeyValuePair<int, string>>)GetValue(expression, html.Model);

            var count = 1;
            foreach (var innerItem in items)
            {
                var input = new MultiLevelTag("input");
                input.Attributes.Add("id", $"{id}_{count}");
                input.Attributes.Add("name", $"{id}_{count}");
                input.Attributes.Add("type", "checkbox");

                var label = new MultiLevelTag("label");
                label.Attributes.Add("for", $"{id}_{count}");
                label.SetInnerText(innerItem.Value);

                var checkboxDiv = new MultiLevelTag("div");
                checkboxDiv.AddCssClass("form-checkbox");

                checkboxDiv.Add(input);
                checkboxDiv.Add(label);

                div.Add(checkboxDiv);
                count++;
            }

            if (helpTextAttr != null)
            {
                var helpTextDiv = new MultiLevelTag("div");
                helpTextDiv.AddCssClass("form-help");
                helpTextDiv.InnerHtml = helpTextAttr.HelpText;
                div.Add(helpTextDiv);
            }

            return MvcHtmlString.Create(div.ToString());
        }
    }
}
