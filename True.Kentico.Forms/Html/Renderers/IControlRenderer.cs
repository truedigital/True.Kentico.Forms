using True.Kentico.Forms.Forms.FormParts;

namespace True.Kentico.Forms.Html.Renderers
{
    public interface IControlRenderer
    {
        string Render(IControl control);
    }
}
