using CMS.FormEngine;
using True.Kentico.Forms.Forms.FormParts;

namespace True.Kentico.Forms.Forms.ControlValidationFactory
{
    public interface IControlValidationFactory
    {
        IControlValidation Create(FieldMacroRule rule);
    }
}