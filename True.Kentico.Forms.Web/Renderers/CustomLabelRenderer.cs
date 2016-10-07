using System;
using True.Kentico.Forms.Forms.FormParts;
using True.Kentico.Forms.Html;
using True.Kentico.Forms.Html.Renderers;

namespace True.Kentico.Forms.Web.Renderers
{
    public class CustomLabelRenderer : IControlRenderer
    {
        public string Render(IControl control)
        {
            if (string.IsNullOrWhiteSpace(control.Label))
                return "";

            var id = control.Name;
            var required = control.IsRequired ? " form-label--required" : string.Empty;
            var tb = new MultiLevelTag("label") { InnerHtml = $"{control.Label}" };
            tb.Attributes.Add("for", id);
            tb.Attributes.Add("class", $"form-label{required}");
            return tb.ToString();
        }

        public string Render(IControl control, object htmlAttributes)
        {
            throw new NotImplementedException();
        }
    }
}