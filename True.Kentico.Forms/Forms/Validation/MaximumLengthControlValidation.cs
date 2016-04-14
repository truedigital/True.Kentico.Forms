using True.Kentico.Forms.Forms.FormParts;

namespace True.Kentico.Forms.Forms.Validation
{
    public  class MaximumLengthControlValidation : ControlValidation
    {
        public override bool Validate(string value)
        {
            return true;
        }
    }
}