using System.Collections.Generic;

namespace True.KenticoForms.Forms
{
    public interface IControl
    {
        string Name { get; set; }
        string Label { get; set; }
        ControlType Type { get; set; }
        IList<IControlValidation> Validation { get; set; }
        bool IsRequired { get; set; }
        string SubmittedValue { get; set; }
        string DefaultValue { get; set; }

        bool HasMultipleDefaultValues { get; set; }
        IEnumerable<string> DefaultValues { get; }

        string ValidationKeys { get; }

        bool Validate();
    }
}