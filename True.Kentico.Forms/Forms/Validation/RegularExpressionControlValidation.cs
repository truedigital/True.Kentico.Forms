using System.CodeDom;
using System.Text.RegularExpressions;
using CMS.Helpers;
using True.Kentico.Forms.Forms.FormParts;

namespace True.Kentico.Forms.Forms.Validation
{
    public class RegularExpressionControlValidation : ControlValidation
    {
        public override bool Validate(object value)
        {
            return new Regex(ValidationValue).IsMatch((string)value);
        }
    }
}