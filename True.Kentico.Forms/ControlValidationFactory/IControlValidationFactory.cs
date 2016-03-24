using CMS.FormEngine;
using True.KenticoForms.Forms;

namespace True.KenticoForms.ControlValidationFactory
{
    public interface IControlValidationFactory
    {
        IControlValidation Create(FieldMacroRule rule);
    }
}