using CMS.FormEngine;
using True.KenticoForms.Forms;

namespace True.KenticoForms.ControlValidationFactory
{
    internal class MaximumValueControlValidationFactory : IControlValidationFactory
    {
        public IControlValidation Create(FieldMacroRule info)
        {
            var parser = new XmlRulesParser();
            var rule = parser.GetXmlRules(info);

            return new ControlValidation
            {
                HasValue = true,
                ValidationValue = rule.Rule.Properties.T,
                ValidationRule = "maximum-value",
                ValidationErrorMessage = string.IsNullOrEmpty(info.ErrorMessage) ? "Value is greater than maximum" : info.ErrorMessage
            };
        }
    }
}