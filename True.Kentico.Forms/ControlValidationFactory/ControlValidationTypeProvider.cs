namespace True.KenticoForms.ControlValidationFactory
{
    internal class ControlValidationTypeProvider : IControlValidationTypeProvider
    {
        public ValidationType GetValidationType(string rule)
        {
            if (rule.Contains(@"n=\""Email\"""))
                return ValidationType.Email;

            if (rule.Contains(@"n=\""MaxLength\"""))
                return ValidationType.MaximumLength;

            if (rule.Contains(@"n=\""MaxValue\"""))
                return ValidationType.MaximumValue;

            if (rule.Contains(@"n=\""MinLength\"""))
                return ValidationType.MinimumLength;

            if (rule.Contains(@"n=\""MinValue\"""))
                return ValidationType.MinimumValue;

            if (rule.Contains(@"n=\""DateFrom\"""))
                return ValidationType.DateFrom;

            if (rule.Contains(@"n=\""DateTo\"""))
                return ValidationType.DateTo;

            if (rule.Contains(@"n=\""RegExp\"""))
                return ValidationType.RegularExpression;

            return ValidationType.Unknown;
        }
    }
}