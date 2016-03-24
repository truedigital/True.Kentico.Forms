namespace True.KenticoForms.Forms
{
    public interface IControlValidation
    {
        string ValidationRule { get; set; }
        string ValidationErrorMessage { get; set; }
        bool HasValue { get; set; }
        string ValidationValue { get; set; }

        bool Validate(string value);
    }
}