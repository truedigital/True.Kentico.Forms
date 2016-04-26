using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Helpers;
using True.Kentico.Forms.Forms.FormParts;

namespace True.Kentico.Forms.Forms.Validation
{
    public class CompareToControlValidation : ControlValidation
    {
        public override bool Validate(object value)
        {
            // this'll be interesting
            // it needs to compare its submitted value with the submitted value of another control

            return true;
        }
    }
}
