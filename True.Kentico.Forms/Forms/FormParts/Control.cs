using System.Collections.Generic;
using System.Web;

namespace True.Kentico.Forms.Forms.FormParts
{
    public class Control : IControl
    {
        public Control()
        {
            Validation = new List<IControlValidation>();
            DefaultValues = new Dictionary<string, bool>();
        }

        public string Name { get; set; }
        public string Label { get; set; }
        public ControlType Type { get; set; }
        public IList<IControlValidation> Validation { get; set; }
        public bool IsRequired { get; set; }

        public object SubmittedValue { get; set; }

        public string DefaultValue { get; set; }
        public string ExplanationText { get; set; }
        public string Tooltip { get; set; }
        public bool HasMultipleDefaultValues { get; set; }
        public IDictionary<string, bool> DefaultValues { get; set; }

        public bool IsValid()
        {
            if (IsRequired && HasValue())
                return false;

            var isValid = true;

            foreach (var validation in Validation)
            {
                isValid &= validation.Validate(SubmittedValue);
            }

            return isValid;
        }

        private bool HasValue()
        {
            var submittedString = SubmittedValue as string;
            if (submittedString != null)
                return string.IsNullOrWhiteSpace(submittedString);

            var submittedValue = SubmittedValue as HttpPostedFileBase;
            return submittedValue != null;
        }
    }

    public class CalendarControl : Control
    {
        public CalendarControl()
        {
            Type = ControlType.Calendar;
        }
    }

    public class CheckBoxControl : Control
    {
        public CheckBoxControl()
        {
            Type = ControlType.CheckBox;
        }
    }

    public class CountryControl : Control
    {
        public CountryControl()
        {
            Type = ControlType.Country;
        }
    }

    public class DropDownListControl : Control
    {
        public DropDownListControl()
        {
            Type = ControlType.DropDownList;
        }
    }

    public class EmailControl : Control
    {
        public EmailControl()
        {
            Type = ControlType.Email;
        }
    }

    public class UploadFileControl : Control
    {
        public UploadFileControl()
        {
            Type = ControlType.UploadFile;
        }
    }

    public class HtmlAreaControl : Control
    {
        public HtmlAreaControl()
        {
            Type = ControlType.HtmlArea;
        }
    }

    public class ListBoxControl : Control
    {
        public ListBoxControl()
        {
            Type = ControlType.ListBox;
        }
    }

    public class MultipleChoiceControl : Control
    {
        public MultipleChoiceControl()
        {
            Type = ControlType.MultipleChoice;
        }
    }

    public class RadioButtonControl : Control
    {
        public RadioButtonControl()
        {
            Type = ControlType.RadioButton;
        }
    }

    public class TextAreaControl : Control
    {
        public TextAreaControl()
        {
            Type = ControlType.TextArea;
        }
    }

    public class TextBoxControl : Control
    {
        public TextBoxControl()
        {
            Type = ControlType.TextBox;
        }
    }

    public class UnknownControl : Control
    {
        public UnknownControl()
        {
            Type = ControlType.Unknown;
        }
    }

}