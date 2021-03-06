﻿using System;
using True.Kentico.Forms.Forms.FormParts;

namespace True.Kentico.Forms.Html.Renderers
{
    internal class DefaultEmailControlRenderer : BaseControlRenderer
    {
        public override string Render(IControl control, object htmlAttributes)
        {
            var id = control.Name;
            var displayName = !string.IsNullOrEmpty(control.Label) ? control.Label : control.Name;

            var div = new MultiLevelTag("div");
            div.AddCssClass("form-inner");

            var input = new MultiLevelTag("input");
            input.Attributes.Add("id", id);
            input.Attributes.Add("name", id);
            input.Attributes.Add("type", "email");
            input.Attributes.Add("value", control.DefaultValue);

            CustomHtml(input, htmlAttributes);

            IsRequired(control, input, displayName);

            foreach (var validation in control.Validation)
            {
                input.Attributes.Add($"data-rule-{validation.ValidationRule}", validation.ValidationValue);
                input.Attributes.Add($"data-msg-{validation.ValidationRule}", validation.ValidationErrorMessage);
            }

            div.Add(input);

            ExplanationText(control, div);
            ToolTip(control, input);

            return div.ToString();
        }

        public override string Render(IControl control)
        {
            return Render(control, null);
        }
    }
}