using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Helpers;
using True.Kentico.Forms.Forms.FormParts;

namespace True.Kentico.Forms.Forms.Validation
{
    public class DateFromControlValidation : ControlValidation
    {
        public override bool Validate(object value)
        {
            var defaultValue = DateTime.MinValue;
            if (!DateTime.TryParse(ValidationValue, out defaultValue)) return true;

            var submittedValue = value as string;
            if (submittedValue != null)
            {
                return ValidationHelper.IsDateTime(value)
                    && ValidationHelper.GetDateTime(value, DateTime.MaxValue) <= defaultValue;
            }

            return true;
        }
    }
}
