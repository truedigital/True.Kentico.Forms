using System;
using True.Kentico.Forms.Forms.FormParts;

namespace True.Kentico.Forms.Html.Renderers
{
    internal class DefaultHtmlEditorControlRenderer : BaseControlRenderer
    {
        public override string Render(IControl control, object htmlAttributes)
        {
            var id = control.Name;

            var displayName = !string.IsNullOrEmpty(control.Label) ? control.Label : control.Name;

            var div = new MultiLevelTag("div");
            div.AddCssClass("form-inner");

            var rte = new MultiLevelTag("textarea");
            rte.Attributes.Add("id", id);
            rte.Attributes.Add("name", id);
            rte.AddCssClass("rich-text-editor");

            CustomHtml(rte, htmlAttributes);

            IsRequired(control, rte, displayName);

            div.Add(rte);

            ExplanationText(control, div);

            ToolTip(control, rte);

            return div.ToString();
        }

        public override string Render(IControl control)
        {
            return Render(control, null);
        }
    }
}