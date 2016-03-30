using System;
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
        public static IHtmlString CheckboxFor<TModel, TControl>(this KenticoForm<TModel> html, TControl control) where TControl : IControl
        {
            var id = control.Name;

            var displayName = !string.IsNullOrEmpty(control.Label) ? control.Label : control.Name;
            
            var div = new MultiLevelTag("div");
            div.AddCssClass("form-inner");

            var input = new MultiLevelTag("input");
            input.Attributes.Add("id", $"{id}");
            input.Attributes.Add("name", id);
            input.Attributes.Add("type", "checkbox");

            if (control.IsRequired)
                input.Attributes.Add("required", null);

            foreach (var validation in control.Validation)
            {
                input.Attributes.Add($"data-rule-{validation.ValidationRule}", validation.ValidationValue);
                input.Attributes.Add($"data-msg-{validation.ValidationRule}", validation.ValidationErrorMessage);
            }

            var label = new MultiLevelTag("label");
            label.Attributes.Add("for", $"{id}");
            label.SetInnerText(displayName);

            var radioDiv = new MultiLevelTag("div");
            radioDiv.AddCssClass("form-radio");

            radioDiv.Add(input);
            radioDiv.Add(label);

            div.Add(radioDiv);

            //if (helpTextAttr != null)
            //{
            //    var helpTextDiv = new MultiLevelTag("div");
            //    helpTextDiv.AddCssClass("form-help");
            //    helpTextDiv.InnerHtml = helpTextAttr.HelpText;
            //    div.Add(helpTextDiv);
            //}

            return MvcHtmlString.Create(div.ToString());
        }
    }
}
