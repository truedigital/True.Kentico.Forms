using System;
using True.Kentico.Forms.Forms.FormParts;

namespace True.Kentico.Forms.Html.Renderers
{
    internal class DefaultCheckBoxControlRenderer : IControlRenderer
    {
        public string Render(IControl control)
        {
            var id = control.Name;

            var displayName = !string.IsNullOrEmpty(control.Label) ? control.Label : control.Name;

            var div = new MultiLevelTag("div");
            div.AddCssClass("form-inner");

            var input = new MultiLevelTag("input");
            input.Attributes.Add("id", $"{id}");
            input.Attributes.Add("name", id);
            input.Attributes.Add("type", "checkbox");

            if (control.DefaultValue == "True")
            {
                input.Attributes.Add("checked", "");
            }

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

          

            div.Add(input);
            div.Add(label);

            if (!String.IsNullOrWhiteSpace(control.ExplanationText))
            {
                var helpTextDiv = new MultiLevelTag("div");
                helpTextDiv.AddCssClass("form-help");
                helpTextDiv.InnerHtml = control.ExplanationText;
                div.Add(helpTextDiv);
            }
            if (!String.IsNullOrWhiteSpace(control.Tooltip))
            {
                input.Attributes.Add("title", control.Tooltip);
            }
            return div.ToString();
        }
    }
}