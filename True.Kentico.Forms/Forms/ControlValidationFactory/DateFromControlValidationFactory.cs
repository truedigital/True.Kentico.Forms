using CMS.FormEngine;
using True.Kentico.Forms.Forms.FormParts;

namespace True.Kentico.Forms.Forms.ControlValidationFactory
{
    internal class DateFromControlValidationFactory : IControlValidationFactory
    {
        public IControlValidation Create(FieldMacroRule info)
        {
            var parser = new XmlRulesParser();
            var rule = parser.GetXmlRules(info);

            return new ControlValidation
            {
                HasValue = true,
                ValidationValue = rule.Rule.Properties.T,
                ValidationRule = "date-from",
                ValidationErrorMessage = string.IsNullOrEmpty(info.ErrorMessage) ? "Date is less than minimum" : info.ErrorMessage
            };
        }
    }
}