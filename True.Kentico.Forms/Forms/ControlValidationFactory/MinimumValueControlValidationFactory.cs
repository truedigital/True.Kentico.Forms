using CMS.FormEngine;
using True.Kentico.Forms.Forms.FormParts;
using True.Kentico.Forms.Forms.Validation;

namespace True.Kentico.Forms.Forms.ControlValidationFactory
{
    internal class MinimumValueControlValidationFactory : IControlValidationFactory
    {
        public IControlValidation Create(FieldMacroRule info)
        {
            var parser = new XmlRulesParser();
            var rule = parser.GetXmlRules(info);

            return new MinimumValueControlValidation
            {
                HasValue = true,
                ValidationValue = rule.Rule.Properties.T,
                ValidationRule = "minimum-value",
                ValidationErrorMessage = string.IsNullOrEmpty(info.ErrorMessage) ? "Value is less than minimum" : info.ErrorMessage
            };
        }
    }
}