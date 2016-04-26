using System.Collections.Generic;
using CMS.FormEngine;
using True.Kentico.Forms.Forms.FormParts;
using True.Kentico.Forms.Forms.Validation;

namespace True.Kentico.Forms.Forms.ControlValidationFactory
{
    public class ControlValidationFactory : IControlValidationFactory
    {
        private static readonly Dictionary<ValidationType, IControlValidationFactory> ControlValidationFactories = new Dictionary<ValidationType, IControlValidationFactory>
        {
            {ValidationType.CompareTo, new CompareToControlValidationFactory()},
            {ValidationType.Email, new EmailControlValidationFactory()},
            {ValidationType.MaximumValue, new MaximumValueControlValidationFactory()},
            {ValidationType.MaximumLength, new MaximumLengthControlValidationFactory()},
            {ValidationType.MinimumValue, new MinimumValueControlValidationFactory()},
            {ValidationType.MinimumLength, new MinimumLengthControlValidationFactory()},
            {ValidationType.DateFrom, new DateFromControlValidationFactory()},
            {ValidationType.DateTo, new DateToControlValidationFactory()},
            {ValidationType.RegularExpression, new RegularExpressionControlValidationFactory()}
        };

        public IControlValidation Create(FieldMacroRule rule)
        {
            var typeProvider = new ControlValidationTypeProvider();
            var type = typeProvider.GetValidationType(rule.MacroRule);

            IControlValidationFactory factory;
            if (ControlValidationFactories.TryGetValue(type, out factory))
            {
                return factory.Create(rule);
            }

            return null;
        }
    }
}