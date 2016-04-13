using System;
using True.Kentico.Forms.Forms.FormParts;

namespace True.Kentico.Forms.Html.Renderers
{
    internal class DefaultLabelControlRenderer
        : IControlRenderer
    {
        public string Render(IControl control)
        {
            if (String.IsNullOrWhiteSpace(control.Label))
            {
                return "";
            }
            var id = control.Name;
            var required = control.IsRequired ? " form-label--required" : string.Empty;
            var tb = new MultiLevelTag("label") { InnerHtml = $"{control.Label}" };
            tb.Attributes.Add("for", id);
            tb.Attributes.Add("class", $"form-label{required}");
            return tb.ToString();
        }
    }
}