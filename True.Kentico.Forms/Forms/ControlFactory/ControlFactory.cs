using System.Collections.Generic;
using CMS.FormEngine;
using CMS.Helpers;
using True.Kentico.Forms.Forms.FormParts;

namespace True.Kentico.Forms.Forms.ControlFactory
{
    public class ControlFactory : IControlFactory
    {
        private static readonly Dictionary<string, IControlFactory> ControlFactories = new Dictionary<string, IControlFactory>
        {
            {"CalendarControl", new TypedControlFactory<CalendarControl>()},
            {"countryControl", new TypedControlFactory<CountryControl>()},
            {"CheckBoxControl", new TypedControlFactory<CheckBoxControl>()},
            {"TextBoxControl", new TypedControlFactory<TextBoxControl>()},
            {"TextAreaControl", new TypedControlFactory<TextAreaControl>()},
            {"HtmlAreaControl", new TypedControlFactory<HtmlAreaControl>()},
            {"emailinput", new TypedControlFactory<EmailControl>()},
            //{"SecurityCode", new TypedControlFactory()},
            //{"UploadControl", new TypedControlFactory()},

            {"DropDownListControl", new MultiValueTypedControlFactory<DropDownListControl>()},
            {"MultipleChoiceControl", new MultiValueTypedControlFactory<MultipleChoiceControl>()},
            {"RadioButtonsControl", new MultiValueTypedControlFactory<RadioButtonControl>()},
            {"ListBoxControl", new MultiValueTypedControlFactory<ListBoxControl>()},
        };

        public IControl Create(FormFieldInfo info)
        {
            IControlFactory factory;
            if (ControlFactories.TryGetValue(ValidationHelper.GetString(info.Settings["controlName"], string.Empty), out factory))
                return factory.Create(info);

            return null;
        }
    }
}