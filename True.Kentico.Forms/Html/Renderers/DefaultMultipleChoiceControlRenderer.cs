using System;
using True.Kentico.Forms.Forms.FormParts;

namespace True.Kentico.Forms.Html.Renderers
{
    internal class DefaultMultipleChoiceControlRenderer : IControlRenderer
    {
        public string Render(IControl control)
        {
            var id = control.Name;

            //var helpTextAttr = GetAttribute<HelpTextAttribute>(item);

            var div = new MultiLevelTag("div");
            div.AddCssClass("form-inner");

            var items = control.DefaultValues;

            var count = 1;
            foreach (var innerItem in items)
            {
                var input = new MultiLevelTag("input");
                input.Attributes.Add("id", $"{id}_{count}");
                input.Attributes.Add("name", $"{id}");
                input.Attributes.Add("value", $"{innerItem}");
                input.Attributes.Add("type", "checkbox");

                if (control.IsRequired)
                {
                    input.Attributes.Add("required", null);
                    input.Attributes.Add("minlength", "1");
                }

                var label = new MultiLevelTag("label");
                label.Attributes.Add("for", $"{id}_{count}");
                label.SetInnerText(innerItem);

                var checkboxDiv = new MultiLevelTag("div");
                checkboxDiv.AddCssClass("form-checkbox");

                checkboxDiv.Add(input);
                checkboxDiv.Add(label);

                div.Add(checkboxDiv);
                count++;
            }

            if (control.IsRequired)
            {
                div.Attributes.Add("required", null);
                div.Attributes.Add("data-msg-required", $"{control.Label} is required");
            }

            if (!String.IsNullOrWhiteSpace(control.ExplanationText))
            {
                var helpTextDiv = new MultiLevelTag("div");
                helpTextDiv.AddCssClass("form-help");
                helpTextDiv.InnerHtml = control.ExplanationText;
                div.Add(helpTextDiv);
            }
            if (!String.IsNullOrWhiteSpace(control.Tooltip))
            {
                div.Attributes.Add("title", control.Tooltip);
            }

            return div.ToString();
        }
    }
}