using System.Collections.Generic;

namespace True.Kentico.Forms.Forms.FormParts
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
        string ExplanationText { get; set; }
        string Tooltip { get; set; }

        bool HasMultipleDefaultValues { get; set; }
        IDictionary<string, bool> DefaultValues { get; set; }

        bool IsValid();
    }
}