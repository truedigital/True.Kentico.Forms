using True.Kentico.Forms.Forms.FormParts;

namespace True.Kentico.Forms.Forms.Validation
{
    public class MinimumLengthControlValidation : ControlValidation
    {
        public override bool Validate(object value)
        {
            var length = 0;
            if (!int.TryParse(ValidationValue, out length)) return true;

            var submittedValue = value as string;
            if (submittedValue != null)
            {
                return submittedValue.Length >= length;
            }

            return true;
        }
    }
}