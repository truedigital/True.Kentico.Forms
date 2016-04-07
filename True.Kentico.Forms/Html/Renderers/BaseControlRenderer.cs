using True.Kentico.Forms.Forms.FormParts;

namespace True.Kentico.Forms.Html.Renderers
{
    internal abstract class BaseControlRenderer : IControlRenderer
    {
        internal virtual MultiLevelTag IsRequired(IControl control, MultiLevelTag controlTag, string displayName)
        {
            if (!control.IsRequired) return controlTag;

            controlTag.Attributes.Add("required", null);
            controlTag.Attributes.Add("data-msg-required", $"{displayName} is required");

            return controlTag;
        }

        public abstract string Render(IControl control);
    }
}