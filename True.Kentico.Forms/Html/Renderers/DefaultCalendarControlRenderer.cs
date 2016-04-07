using System;
using True.Kentico.Forms.Forms.FormParts;

namespace True.Kentico.Forms.Html.Renderers
{
    internal class DefaultCalendarControlRenderer : BaseControlRenderer
    {
        public override string Render(IControl control)
        {
            var id = control.Name;

            var displayName = !string.IsNullOrEmpty(control.Label) ? control.Label : control.Name;

            var div = new MultiLevelTag("div");
            div.AddCssClass("form-inner");

            var input = new MultiLevelTag("input");
            input.Attributes.Add("id", id);
            input.Attributes.Add("name", id);
            input.Attributes.Add("type", "text");
            input.AddCssClass("datepicker");

            IsRequired(control, input, displayName);

            div.Add(input);

            ExplanationText(control, div);
            ToolTip(control, input);

            return div.ToString();
        }
    }
}