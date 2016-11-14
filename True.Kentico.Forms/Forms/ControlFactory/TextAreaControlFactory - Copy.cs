using System;
using System.Collections.Generic;
using System.Linq;
using CMS.FormEngine;
using True.Kentico.Forms.Forms.ControlValidationFactory;
using True.Kentico.Forms.Forms.FormParts;
using System.Collections;

namespace True.Kentico.Forms.Forms.ControlFactory
{
    internal class TextAreaControlFactory<T> : IControlFactory where T : IControl, new()
    {
        private readonly IControlValidationFactory _validationFactory;

        public TextAreaControlFactory()
            : this(new ControlValidationFactory.ControlValidationFactory())
        {
        }

        public TextAreaControlFactory(IControlValidationFactory validationFactory)
        {
            _validationFactory = validationFactory;
        }

        public IControl Create(FormFieldInfo info)
        {
            var control = new T
            {
                Name = info.Name,
                Label = info.Caption,
                IsRequired = !info.AllowEmpty,
                HasMultipleDefaultValues = true,
                ExplanationText = info.GetPropertyValue(FormFieldPropertyEnum.ExplanationText),
                Tooltip = info.GetPropertyValue(FormFieldPropertyEnum.FieldDescription)
            };

            var defaultValues = info.GetPropertyValue(FormFieldPropertyEnum.DefaultValue)?
                .Split(new[] { "|" }, StringSplitOptions.RemoveEmptyEntries);

            control.Settings = info.Settings
                .Cast<DictionaryEntry>()
                .ToDictionary(item => (string)item.Key, item => (string)item.Value);

            foreach (var validationInfo in info.FieldMacroRules)
            {
                var validation = _validationFactory.Create(validationInfo);
                if (validation == null)
                    continue;

                control.Validation.Add(validation);
            }

            return control;
        }
    }
}