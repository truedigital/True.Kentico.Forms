using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using True.Kentico.Forms.Forms.FormParts;
using True.Kentico.Forms.Html.ExtraAttributes;

namespace True.Kentico.Forms.Html.Extensions
{
    public static partial class KenticoFormHelperExtensions
    {
        public static IHtmlString DropDownListFor<TModel, TControl>(this KenticoForm<TModel> html, TControl control) where TControl : IControl
        {
            var id = control.Name;

            //var dispAttr = GetAttribute<DisplayAttribute>(item);
            var displayName = !string.IsNullOrEmpty(control.Label) ? control.Label : control.Name;

            //var reqAttr = GetAttribute<RequiredAttribute>(item);
            //var helpTextAttr = GetAttribute<HelpTextAttribute>(item);

            var div = new MultiLevelTag("div");
            div.AddCssClass("form-inner");

            var ddl = new MultiLevelTag("select");
            ddl.Attributes.Add("id", id);
            ddl.Attributes.Add("name", id);

            var items = control.DefaultValues;

            foreach (var innerItem in items)
                ddl.Add(new MultiLevelTag("option") { InnerHtml = innerItem });

            if (control.IsRequired)
            {
                ddl.Attributes.Add("required", null);
                ddl.Attributes.Add("data-msg-required", $"{displayName} is required");
            }

            div.Add(ddl);

            //if (helpTextAttr != null)
            //{
            //    var helpTextDiv = new MultiLevelTag("div");
            //    helpTextDiv.AddCssClass("form-help");
            //    helpTextDiv.InnerHtml = helpTextAttr.HelpText;
            //    div.Add(helpTextDiv);
            //}

            return MvcHtmlString.Create(div.ToString());
        }

        public static IHtmlString DropDownListFor<TModel, TProperty>(this KenticoForm<TModel> html, Expression<Func<TModel, TProperty>> expression) where TProperty : List<KeyValuePair<int, string>>
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

            var items = (List<KeyValuePair<int, string>>)GetValue(expression, html.Model);

            foreach (var innerItem in items)
                ddl.Add(new MultiLevelTag("option") { InnerHtml = innerItem.Value });

            if (reqAttr != null)
            {
                ddl.Attributes.Add("required", null);
                ddl.Attributes.Add("data-msg-required", $"{displayName} is required");
            }

            div.Add(ddl);

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
