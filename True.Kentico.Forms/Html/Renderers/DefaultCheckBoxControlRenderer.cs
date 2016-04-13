using True.Kentico.Forms.Forms.FormParts;

namespace True.Kentico.Forms.Html.Renderers
{
    internal class DefaultCheckBoxControlRenderer : BaseControlRenderer
    {
        public override string Render(IControl control)
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

            // todo why does this have its own label?
            var label = new MultiLevelTag("label");
            label.Attributes.Add("for", $"{id}");
            label.SetInnerText(control.DefaultValue);

            div.Add(input);
            div.Add(label);

            ExplanationText(control, div);
            ToolTip(control, input);

            return div.ToString();
        }
    }
}