using True.Kentico.Forms.Forms.FormParts;

namespace True.Kentico.Forms.Html.Renderers
{
    internal class DefaultRadioButtonListControlRenderer : BaseControlRenderer
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
                input.Attributes.Add("value", $"{innerItem.Key}");
                input.Attributes.Add("name", id);
                input.Attributes.Add("type", "radio");
                if (innerItem.Value) input.Attributes.Add("checked", null);

                if (count == 1 && control.IsRequired)
                    input.Attributes.Add("required", null);

                CustomHtml(input, htmlAttributes);

                var label = new MultiLevelTag("label");
                label.Attributes.Add("for", $"{id}_{count}");
                label.SetInnerText(innerItem.Key);

                var radioDiv = new MultiLevelTag("div");
                radioDiv.AddCssClass("form-radio");

                radioDiv.Add(input);
                radioDiv.Add(label);

                div.Add(radioDiv);
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