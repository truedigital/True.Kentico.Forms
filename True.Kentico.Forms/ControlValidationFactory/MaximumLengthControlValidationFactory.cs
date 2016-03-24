using CMS.FormEngine;
using True.KenticoForms.Forms;

namespace True.KenticoForms.ControlValidationFactory
{
    internal class MaximumLengthControlValidationFactory : IControlValidationFactory
    {
        public IControlValidation Create(FieldMacroRule info)
        {
            var parser = new XmlRulesParser();
            var rule = parser.GetXmlRules(info);

            return new ControlValidation
            {
                HasValue = true,
                ValidationValue = rule.Rule.Properties.T,
                ValidationRule = "maximum-length",
                ValidationErrorMessage = string.IsNullOrEmpty(info.ErrorMessage) ? "Length is greater than maximum" : info.ErrorMessage
            };
        }
    }
}