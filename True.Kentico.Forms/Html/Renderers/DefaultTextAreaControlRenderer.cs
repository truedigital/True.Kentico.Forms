using System;
using True.Kentico.Forms.Forms.FormParts;

namespace True.Kentico.Forms.Html.Renderers
{
    internal class DefaultTextAreaControlRenderer : BaseControlRenderer
    {
        public override string Render(IControl control)
        {
            var id = control.Name;

            var displayName = !string.IsNullOrEmpty(control.Label) ? control.Label : control.Name;
            
            var div = new MultiLevelTag("div");
            div.AddCssClass("form-inner");

            var textarea = new MultiLevelTag("textarea");
            textarea.Attributes.Add("id", id);
            textarea.Attributes.Add("name", id);

            IsRequired(control, textarea, displayName);

            foreach (var validation in control.Validation)
            {
                textarea.Attributes.Add($"data-rule-{validation.ValidationRule}", validation.ValidationValue);
                textarea.Attributes.Add($"data-msg-{validation.ValidationRule}", validation.ValidationErrorMessage);
            }

            div.Add(textarea);

            if (!String.IsNullOrWhiteSpace(control.ExplanationText))
            {
                var helpTextDiv = new MultiLevelTag("div");
                helpTextDiv.AddCssClass("form-help");
                helpTextDiv.InnerHtml = control.ExplanationText;
                div.Add(helpTextDiv);
            }
            if (!String.IsNullOrWhiteSpace(control.Tooltip))
            {
                textarea.Attributes.Add("title", control.Tooltip);
            }
            return div.ToString();
        }
    }
}