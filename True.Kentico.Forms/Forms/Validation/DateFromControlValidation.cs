using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using True.Kentico.Forms.Forms.FormParts;

namespace True.Kentico.Forms.Forms.Validation
{
    public class DateFromControlValidation : ControlValidation
    {
        public override bool Validate(Object value)
        {
            bool isValid = true;

            //todovalidate the value by comparing the value versus the control validation value
            return isValid;
        }
    }
}
