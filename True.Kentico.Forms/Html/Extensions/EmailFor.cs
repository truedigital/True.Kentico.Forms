using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using True.Kentico.Forms.Forms.FormParts;
using True.Kentico.Forms.Html.ExtraAttributes;
using CompareAttribute = System.ComponentModel.DataAnnotations.CompareAttribute;

namespace True.Kentico.Forms.Html.Extensions
{
    public static partial class KenticoFormHelperExtensions
    {
        public static IHtmlString EmailFor<TModel, TControl>(this KenticoForm<TModel> html, TControl control) where TControl : IControl
        {
            // var item = (MemberExpression)expression.Body;
            var id = control.Name;

            // var dispAttr = GetAttribute<DisplayAttribute>(item);
            var displayName = control.Label;// != null ? dispAttr.Name : item.Member.Name;

            var reqAttr = control.IsRequired;
            // todo var helpTextAttr = "Something";
            // todo var equalTo = GetAttribute<CompareAttribute>(item);

            var div = new MultiLevelTag("div");
            div.AddCssClass("form-inner");

            var input = new MultiLevelTag("input");
            input.Attributes.Add("id", id);
            input.Attributes.Add("name", id);
            input.Attributes.Add("type", "email");

            /* todo if (equalTo != null)
            {
                input.Attributes.Add("equalTo", $"#{equalTo.OtherProperty}");
            }*/

            if (reqAttr != null)
            {
                input.Attributes.Add("required", null);
                input.Attributes.Add("data-msg-required", $"{displayName} is required");
            }

            input.Attributes.Add("data-msg-email", $"{displayName} is invalid");

            input.Attributes.Add("data-msg-equalto", $"Does not match");

            div.Add(input);

            /* todo help text if (helpTextAttr != null)
            {
                var helpTextDiv = new MultiLevelTag("div");
                helpTextDiv.AddCssClass("form-help");
                helpTextDiv.InnerHtml = helpTextAttr.HelpText;
                div.Add(helpTextDiv);
            }*/

            return MvcHtmlString.Create(div.ToString());
        }

        public static IHtmlString EmailFor<TModel, TProperty>(this KenticoForm<TModel> html, Expression<Func<TModel, TProperty>> expression)
        {
            var item = (MemberExpression)expression.Body;
            var id = item.Member.Name;

            var dispAttr = GetAttribute<DisplayAttribute>(item);
            var displayName = dispAttr != null ? dispAttr.Name : item.Member.Name;

            var reqAttr = GetAttribute<RequiredAttribute>(item);
            var helpTextAttr = GetAttribute<HelpTextAttribute>(item);
            var equalTo = GetAttribute<CompareAttribute>(item);

            var div = new MultiLevelTag("div");
            div.AddCssClass("form-inner");

            var input = new MultiLevelTag("input");
            input.Attributes.Add("id", id);
            input.Attributes.Add("name", id);
            input.Attributes.Add("type", "email");

            if (equalTo != null)
            {
                input.Attributes.Add("equalTo", $"#{equalTo.OtherProperty}");
            }

            if (reqAttr != null)
            {
                input.Attributes.Add("required", null);
                input.Attributes.Add("data-msg-required", $"{displayName} is required");
            }

            input.Attributes.Add("data-msg-email", $"{displayName} is invalid");

            input.Attributes.Add("data-msg-equalto", $"Does not match");

            div.Add(input);

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
