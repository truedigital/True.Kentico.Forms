using System;
using True.Kentico.Forms.Forms.FormParts;

namespace True.Kentico.Forms.Html.Renderers
{
    internal class DefaultCheckBoxControlRenderer : BaseControlRenderer
    {
        public override string Render(IControl control, object htmlAttributes)
        {
            var id = control.Name;

            var displayName = !string.IsNullOrEmpty(control.Label) ? control.Label : control.Name;

            var div = new MultiLevelTag("div");
            div.AddCssClass("form-inner");

            var input = new MultiLevelTag("input");
            input.Attributes.Add("id", $"{id}");
            input.Attributes.Add("name", id);
            input.Attributes.Add("type", "checkbox");
            input.Attributes.Add("value", $"{id}");
            CustomHtml(input, htmlAttributes);

            if (control.DefaultValue == "True")
            {
                input.Attributes.Add("checked", "");
            }

            IsRequired(control, input, displayName);

            foreach (var validation in control.Validation)
            {
                input.Attributes.Add($"data-rule-{validation.ValidationRule}", validation.ValidationValue);
                input.Attributes.Add($"data-msg-{validation.ValidationRule}", validation.ValidationErrorMessage);
            }

            var required = control.IsRequired ? " form-label--required" : string.Empty;
            var label = new MultiLevelTag("label");
            label.Attributes.Add("for", $"{id}");
            label.SetInnerText(displayName);
            label.Attributes.Add("class", $"form-label{required}");


            div.Add(input);
            div.Add(label);

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