using True.Kentico.Forms.Forms.FormParts;

namespace True.Kentico.Forms.Forms.Validation
{
    public class MaximumValueControlValidation : ControlValidation
    {
        public override bool Validate(object value)
        {
            var length = 0;
            if (!int.TryParse(ValidationValue, out length)) return true;

            var parsedValue = 0;
            var submittedValue = value as string;
            if (!int.TryParse(submittedValue, out length)) return false;

            return parsedValue <= length;
        }
    }
}