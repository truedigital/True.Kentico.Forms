using True.Kentico.Forms.Forms.ControlValidationFactory;

namespace True.Kentico.Forms.Forms.FormParts
{
    public interface IControlValidation
    {
        ValidationType ValidationType { get; set; }
        string ValidationRule { get; set; }
        string ValidationErrorMessage { get; set; }
        bool HasValue { get; set; }
        string ValidationValue { get; set; }

        bool Validate(string value);
    }
}