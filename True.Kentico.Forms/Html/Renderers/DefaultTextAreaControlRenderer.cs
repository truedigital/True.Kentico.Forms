using System;
using System.Web.Mvc;
using True.Kentico.Forms.Forms.FormParts;

namespace True.Kentico.Forms.Html.Renderers
{
    internal class DefaultTextAreaControlRenderer : BaseControlRenderer
    {
        public override string Render(IControl control, object htmlAttributes)
        {
            var id = control.Name;

            var displayName = !string.IsNullOrEmpty(control.Label) ? control.Label : control.Name;

            var div = new MultiLevelTag("div");
            div.AddCssClass("form-inner");

            var textarea = new MultiLevelTag("textarea");
            textarea.Attributes.Add("id", id);
            textarea.Attributes.Add("name", id);
            textarea.Attributes.Add("value", control.DefaultValue);

            CustomHtml(textarea, htmlAttributes);
            IsRequired(control, textarea, displayName);

            foreach (var validation in control.Validation)
            {
                textarea.Attributes.Add($"data-rule-{validation.ValidationRule}", validation.ValidationValue);
                textarea.Attributes.Add($"data-msg-{validation.ValidationRule}", validation.ValidationErrorMessage);
            }

            foreach (var item in control.Settings)
            {
                AddSettingsHtml(textarea, item);
            }

            div.Add(textarea);

            ExplanationText(control, div);
            ToolTip(control, textarea);

            return div.ToString();
        }

        private void AddSettingsHtml(MultiLevelTag textarea, System.Collections.Generic.KeyValuePair<string, string> item)
        {
            if (item.Key.Equals("rows", StringComparison.OrdinalIgnoreCase) ||
                item.Key.Equals("cols", StringComparison.OrdinalIgnoreCase))
                textarea.Attributes.Add(item.Key.ToLower(), item.Value);
            if (item.Key.Equals("size", StringComparison.OrdinalIgnoreCase))
                textarea.Attributes.Add("maxlength", item.Value);
        }

        public override string Render(IControl control)
        {
            return Render(control, null);
        }
    }
}