namespace True.Kentico.Forms.Forms.FormParts
{
    public interface IControlValidation
    {
        string ValidationRule { get; set; }
        string ValidationErrorMessage { get; set; }
        bool HasValue { get; set; }
        string ValidationValue { get; set; }

        bool Validate(object value);
    }
}