using System.Collections.Generic;
using System.Linq;
using True.Kentico.Forms.Forms.FormParts;

namespace True.Kentico.Forms.Forms.Validation
{
    public class FormValidator
    {
        public Dictionary<string, string> Errors { get; }

        public FormValidator()
        {
            Errors = new Dictionary<string, string>();
        }

        public bool Validate(Form form)
        {
            Errors.Clear();

            foreach (var control in form.Controls)
            {
                if (control.IsValid()) continue;
                //do something appropriate here to get the error messages
                var errors = control.Validation.Select(v => v.ValidationErrorMessage).Aggregate((s0, s1) => s0 + ", " + s1);
                Errors.Add(control.SubmittedValue, errors);
            }

            return !Errors.Any();
        }
    }
}
