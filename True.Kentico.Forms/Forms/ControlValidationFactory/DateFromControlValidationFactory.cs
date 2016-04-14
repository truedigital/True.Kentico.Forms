using CMS.FormEngine;
using True.Kentico.Forms.Forms.FormParts;
using True.Kentico.Forms.Forms.Validation;

namespace True.Kentico.Forms.Forms.ControlValidationFactory
{
    internal class DateFromControlValidationFactory : IControlValidationFactory
    {
        public IControlValidation Create(FieldMacroRule info)
        {
            var parser = new XmlRulesParser();
            var rule = parser.GetXmlRules(info);

            return new DateFromControlValidation
            {
                HasValue = true,
                ValidationValue = rule.Rule.Properties.T,
                ValidationRule = "date-from",
                ValidationErrorMessage = string.IsNullOrEmpty(info.ErrorMessage) ? "Date is less than minimum" : info.ErrorMessage
            };
        }
    }
}