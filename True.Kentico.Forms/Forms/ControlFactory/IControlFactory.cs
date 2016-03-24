using CMS.FormEngine;
using True.Kentico.Forms.Forms.FormParts;

namespace True.Kentico.Forms.Forms.ControlFactory
{
    public interface IControlFactory
    {
        IControl Create(FormFieldInfo info);
    }
}