using CMS.FormEngine;
using True.Kentico.Forms.Forms.FormParts;
using True.Kentico.Forms.Forms.Validation;

namespace True.Kentico.Forms.Forms.ControlValidationFactory
{
    internal class MaximumLengthControlValidationFactory : IControlValidationFactory
    {
        public IControlValidation Create(FieldMacroRule info)
        {
            var parser = new XmlRulesParser();
            var rule = parser.GetXmlRules(info);

            return new MaximumLengthControlValidation
            {
                HasValue = true,
                ValidationValue = rule.Rule.Properties.T,
                ValidationRule = "maxlength",
                ValidationErrorMessage = string.IsNullOrEmpty(info.ErrorMessage) ? "Length is greater than maximum" : info.ErrorMessage
            };
        }
    }
}