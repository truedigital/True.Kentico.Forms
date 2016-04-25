using CMS.Helpers;
using True.Kentico.Forms.Forms.FormParts;

namespace True.Kentico.Forms.Forms.Validation
{
    public class EmailControlValidation : ControlValidation
    {
        public override bool Validate(object value)
        {
            return ValidationHelper.IsEmail(value);
        }
    }
}