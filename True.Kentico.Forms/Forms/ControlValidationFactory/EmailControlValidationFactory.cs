using CMS.FormEngine;
using True.Kentico.Forms.Forms.FormParts;

namespace True.Kentico.Forms.Forms.ControlValidationFactory
{
    internal class EmailControlValidationFactory : IControlValidationFactory
    {
        public IControlValidation Create(FieldMacroRule info)
        {
            return new ControlValidation
            {
                ValidationRule = "email",
                ValidationErrorMessage = string.IsNullOrEmpty(info.ErrorMessage) ? "Please provide your email address" : info.ErrorMessage
            };
        }
    }
}