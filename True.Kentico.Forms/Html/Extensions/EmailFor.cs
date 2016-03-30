using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using CMS.Helpers;
using True.Kentico.Forms.Forms.FormParts;
using True.Kentico.Forms.Html.ExtraAttributes;
using CompareAttribute = System.ComponentModel.DataAnnotations.CompareAttribute;

namespace True.Kentico.Forms.Html.Extensions
{
    public static partial class KenticoFormHelperExtensions
    {
        public static IHtmlString EmailFor<TModel, TControl>(this KenticoForm<TModel> html, TControl control) where TControl : IControl
        {
            var id = control.Name;
            var displayName = !string.IsNullOrEmpty(control.Label) ? control.Label : control.Name;

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

            if (control.IsRequired)
            {
                input.Attributes.Add("required", null);
                input.Attributes.Add("data-msg-required", $"{displayName} is required");
            }

            foreach (var validation in control.Validation)
            {
                input.Attributes.Add($"data-msg-{validation.ValidationRule}", validation.ValidationErrorMessage);
            }

            // input.Attributes.Add("data-msg-equalto", "Does not match");

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
    }
}
