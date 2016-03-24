using CMS.FormEngine;
using True.KenticoForms.Forms;

namespace True.KenticoForms.ControlValidationFactory
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