using System;
using CMS.MacroEngine;

namespace True.Kentico.Forms.Forms.FormParts
{
    public abstract class ControlValidation : IControlValidation
    {
        public string ValidationRule { get; set; }
        public string ValidationErrorMessage { get; set; }
        public bool HasValue { get; set; }
        public string ValidationValue { get; set; }
        public string MacroValidationRule { get; set; }

        public abstract bool Validate(string value);
    }
}