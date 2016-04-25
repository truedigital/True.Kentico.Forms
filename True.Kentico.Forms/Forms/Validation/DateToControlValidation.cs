using System;
using CMS.Helpers;
using True.Kentico.Forms.Forms.FormParts;

namespace True.Kentico.Forms.Forms.Validation
{
    public class DateToControlValidation : ControlValidation
    {
        public override bool Validate(object value)
        {
            var defaultValue = DateTime.MinValue;
            if (!DateTime.TryParse(ValidationValue, out defaultValue)) return true;

            var submittedValue = value as string;
            if (submittedValue != null)
            {
                return ValidationHelper.IsDateTime(value)
                    && ValidationHelper.GetDateTime(value, DateTime.MinValue) >= defaultValue;
            }

            return true;
        }
    }
}