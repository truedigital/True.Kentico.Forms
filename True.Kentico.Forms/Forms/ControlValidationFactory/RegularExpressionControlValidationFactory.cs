using CMS.FormEngine;
using True.Kentico.Forms.Forms.FormParts;

namespace True.Kentico.Forms.Forms.ControlValidationFactory
{
    internal class RegularExpressionControlValidationFactory : IControlValidationFactory
    {
        public IControlValidation Create(FieldMacroRule info)
        {
            var parser = new XmlRulesParser();
            var rule = parser.GetXmlRules(info);

            return new ControlValidation
            {
                HasValue = true,
                ValidationValue = rule.Rule.Properties.T,
                ValidationRule = "regular-expression",
                ValidationErrorMessage = string.IsNullOrEmpty(info.ErrorMessage) ? "Invalid data entered" : info.ErrorMessage,
                MacroValidationRule = info.MacroRule
            };
        }
    }
}