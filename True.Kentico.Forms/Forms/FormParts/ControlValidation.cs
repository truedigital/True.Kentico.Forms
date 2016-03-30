using True.Kentico.Forms.Forms.ControlValidationFactory;

namespace True.Kentico.Forms.Forms.FormParts
{
    public class ControlValidation : IControlValidation
    {
        public ValidationType ValidationType { get; set; }
        public string ValidationRule { get; set; }
        public string ValidationErrorMessage { get; set; }
        public bool HasValue { get; set; }
        public string ValidationValue { get; set; }


        public bool Validate(string value)
        {
            //validate somehow, maybe create a factory that can look up how to validate a given
            //ControlValidation object based on the ValidationRule type, using the ValidationValue
            //and value as arguments to the validation type returned from the factory?

            //alternatively this method could be made abstract/virtual and we could make each
            //validation type override this method to handle validation in a specific way
            //based on what it is validating, this would involve creating derived types
            //for each validation type and for handling the logic for creating the correct
            //ControlValidation type in the ControlFactory

            return true;
        }
    }
}