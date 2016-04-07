using System;
using True.Kentico.Forms.Forms.FormParts;

namespace True.Kentico.Forms.Html.Renderers
{
    internal abstract class BaseControlRenderer : IControlRenderer
    {
        internal virtual void IsRequired(IControl control, MultiLevelTag controlTag, string displayName)
        {
            if (!control.IsRequired) return;

            controlTag.Attributes.Add("required", null);
            controlTag.Attributes.Add("data-msg-required", $"{displayName} is required");
        }

        internal virtual void ExplanationText(IControl control, MultiLevelTag parentTag)
        {
            if (string.IsNullOrWhiteSpace(control.ExplanationText)) return;
            var helpTextDiv = new MultiLevelTag("div");
            helpTextDiv.AddCssClass("form-help");
            helpTextDiv.InnerHtml = control.ExplanationText;
            parentTag.Add(helpTextDiv);
        }

        internal virtual void ToolTip(IControl control, MultiLevelTag parentTag)
        {
            if (string.IsNullOrWhiteSpace(control.Tooltip)) return;
            parentTag.Attributes.Add("title", control.Tooltip);
        }

        public abstract string Render(IControl control);
    }
}