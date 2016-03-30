using CMS.FormEngine;
using True.Kentico.Forms.Forms.FormParts;

namespace True.Kentico.Forms.Html.HtmlControlFactory
{
    public interface IHtmlControlFactory
    {
        IControl Create(FormFieldInfo info);
    }
}