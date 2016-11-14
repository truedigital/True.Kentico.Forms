using System.Collections.Generic;
using System.IO;

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
        IDictionary<string, string> Settings { get; set; }
        IList<string> ValidationErrors { get; set; }
        bool IsValid();
    }

    public interface IFileControl : IControl
    {
        Stream SubmittedData { get; set; }
    }
}