using System;
using System.Collections.Generic;
using System.Linq;
using CMS.FormEngine;
using True.Kentico.Forms.Forms.ControlValidationFactory;
using True.Kentico.Forms.Forms.FormParts;

namespace True.Kentico.Forms.Forms.ControlFactory
{
    internal class MultiValueTypedControlFactory<T> : IControlFactory where T : IControl, new()
    {
        private readonly IControlValidationFactory _validationFactory;

        public MultiValueTypedControlFactory()
            : this(new ControlValidationFactory.ControlValidationFactory())
        {
        }

        public MultiValueTypedControlFactory(IControlValidationFactory validationFactory)
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
                Tooltip = info.GetPropertyValue(FormFieldPropertyEnum.FieldCaption)
            };

            var defaultValues = info.GetPropertyValue(FormFieldPropertyEnum.DefaultValue)?
                .Split(new[] { "|" }, StringSplitOptions.RemoveEmptyEntries);

            control.DefaultValues = info.Settings["Options"].ToString()
                .Replace("##EMPTY##1;", " ")
                .Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries)
                .ToDictionary(item => item,
                    item => defaultValues?.Contains(item) ?? false);

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