using System;
using System.Collections.Generic;
using System.Linq;

namespace True.Kentico.Forms.Forms.FormParts
{
    public class Control : IControl
    {
        public Control()
        {
            Validation = new List<IControlValidation>();
        }

        public string Name { get; set; }
        public string Label { get; set; }
        public ControlType Type { get; set; }
        public IList<IControlValidation> Validation { get; set; }
        public bool IsRequired { get; set; }

        public string SubmittedValue { get; set; }

        public string DefaultValue { get; set; }
        public bool HasMultipleDefaultValues { get; set; }
        public IEnumerable<string> DefaultValues => DefaultValue == null ? Enumerable.Empty<string>() : DefaultValue.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries); 

        public string ValidationKeys
        {
            get
            {
                if (Validation == null)
                    return null;

                var data = Validation
                    .Select(s => s.HasValue
                        ? string.Format("data-validation-{0}-error=\"{1}\" data-validation-{0}-value=\"{2}\"", s.ValidationRule, s.ValidationErrorMessage, s.ValidationValue)
                        : string.Format("data-validation-{0}-error=\"{1}\"", s.ValidationRule, s.ValidationErrorMessage));

                return string.Join(" ", data);

            }
        }
        
        public bool Validate()
        {
            if (string.IsNullOrWhiteSpace(SubmittedValue))
                return false;

            var isValid = true;
            foreach (var validation in Validation)
            {
                isValid &= validation.Validate(SubmittedValue);
            }

            return isValid;
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