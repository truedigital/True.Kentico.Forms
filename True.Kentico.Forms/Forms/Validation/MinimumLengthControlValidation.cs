using True.Kentico.Forms.Forms.FormParts;

namespace True.Kentico.Forms.Forms.Validation
{
    public class MinimumLengthControlValidation : ControlValidation
    {
        public override bool Validate(string value)
        {
            return true;
        }
    }
}