using System;
using True.Kentico.Forms.Forms.FormParts;

namespace True.Kentico.Forms.Html.Renderers
{
    public class DefaultRadioButtonListControlRenderer : IControlRenderer
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
                input.Attributes.Add("value", $"{innerItem}");
                input.Attributes.Add("name", id);
                input.Attributes.Add("type", "radio");

                if (count == 1 && control.IsRequired)
                    input.Attributes.Add("required", null);

                var label = new MultiLevelTag("label");
                label.Attributes.Add("for", $"{id}_{count}");
                label.SetInnerText(innerItem);

                var radioDiv = new MultiLevelTag("div");
                radioDiv.AddCssClass("form-radio");

                radioDiv.Add(input);
                radioDiv.Add(label);

                div.Add(radioDiv);
                count++;
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