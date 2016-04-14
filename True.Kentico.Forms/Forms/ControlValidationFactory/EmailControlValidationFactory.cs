using CMS.FormEngine;
using True.Kentico.Forms.Forms.FormParts;
using True.Kentico.Forms.Forms.Validation;

namespace True.Kentico.Forms.Forms.ControlValidationFactory
{
    internal class EmailControlValidationFactory : IControlValidationFactory
    {
        public IControlValidation Create(FieldMacroRule info)
        {
            return new EmailControlValidation
            {
                ValidationRule = "email",
                ValidationErrorMessage = string.IsNullOrEmpty(info.ErrorMessage) ? "Please provide your email address" : info.ErrorMessage
            };
        }
    }
}