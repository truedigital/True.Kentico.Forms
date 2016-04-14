using CMS.FormEngine;
using True.Kentico.Forms.Forms.FormParts;
using True.Kentico.Forms.Forms.Validation;

namespace True.Kentico.Forms.Forms.ControlValidationFactory
{
    internal class MinimumLengthControlValidationFactory : IControlValidationFactory
    {
        public IControlValidation Create(FieldMacroRule info)
        {
            var parser = new XmlRulesParser();
            var rule = parser.GetXmlRules(info);

            return new MinimumLengthControlValidation()
            {
                HasValue = true,
                ValidationValue = rule.Rule.Properties.T,
                ValidationRule = "minlength",
                ValidationErrorMessage = string.IsNullOrEmpty(info.ErrorMessage) ? "Length is less than minimum" : info.ErrorMessage
            };
        }
    }
}