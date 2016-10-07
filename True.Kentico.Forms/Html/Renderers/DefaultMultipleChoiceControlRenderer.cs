using System;
using True.Kentico.Forms.Forms.FormParts;

namespace True.Kentico.Forms.Html.Renderers
{
    internal class DefaultMultipleChoiceControlRenderer : BaseControlRenderer
    {
        public override string Render(IControl control, object htmlAttributes)
        {
            var id = control.Name;
            var displayName = !string.IsNullOrEmpty(control.Label) ? control.Label : control.Name;

            var div = new MultiLevelTag("div");
            div.AddCssClass("form-inner");

            var items = control.DefaultValues;

            var count = 1;
            foreach (var innerItem in items)
            {
                var input = new MultiLevelTag("input");
                input.Attributes.Add("id", $"{id}_{count}");
                input.Attributes.Add("name", $"{id}");
                input.Attributes.Add("value", $"{innerItem.Key}");
                input.Attributes.Add("type", "checkbox");
                if (innerItem.Value) input.Attributes.Add("checked", null);

                if (control.IsRequired)
                {
                    input.Attributes.Add("required", null);
                    input.Attributes.Add("minlength", "1");
                }

                CustomHtml(input, htmlAttributes);

                var label = new MultiLevelTag("label");
                label.Attributes.Add("for", $"{id}_{count}");
                label.SetInnerText(innerItem.Key);

                var checkboxDiv = new MultiLevelTag("div");
                checkboxDiv.AddCssClass("form-checkbox");

                checkboxDiv.Add(input);
                checkboxDiv.Add(label);

                div.Add(checkboxDiv);
                count++;
            }

            IsRequired(control, div, displayName);
            ExplanationText(control, div);
            ToolTip(control, div);

            return div.ToString();
        }

        public override string Render(IControl control)
        {
            return Render(control, null);
        }
    }
}