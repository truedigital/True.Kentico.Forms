namespace True.Kentico.Forms.Forms.FormParts
{
    public class ControlValidation : IControlValidation
    {
        public string ValidationRule { get; set; }
        public string ValidationErrorMessage { get; set; }
        public bool HasValue { get; set; }
        public string ValidationValue { get; set; }
        public string MacroValidationRule { get; set; }

        public bool Validate(string value)
        {
            //todo this does not work
            //var resolver = MacroResolver.GetInstance();
            //var result = resolver.ResolveMacros(value, new EvaluationContext(resolver, MacroValidationRule));

            //bool isValid;
            //return bool.TryParse(result, out isValid) && isValid;
            return true;
        }
    }
}