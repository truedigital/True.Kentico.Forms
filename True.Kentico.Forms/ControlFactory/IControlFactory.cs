using CMS.FormEngine;
using True.KenticoForms.Forms;

namespace True.KenticoForms.ControlFactory
{
    public interface IControlFactory
    {
        IControl Create(FormFieldInfo info);
    }
}