using CMS.FormEngine;
using True.Kentico.Forms.Forms.ControlValidationFactory;
using True.Kentico.Forms.Forms.FormParts;

namespace True.Kentico.Forms.Forms.ControlFactory
{
    internal class TypedControlFactory<T> : IControlFactory where T : IControl, new()
    {
        private readonly IControlValidationFactory _validationFactory;

        public TypedControlFactory()
            : this(new ControlValidationFactory.ControlValidationFactory())
        {
        }

        public TypedControlFactory(IControlValidationFactory validationFactory)
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
                DefaultValue = info.DefaultValue,
                ExplanationText = info.GetPropertyValue(FormFieldPropertyEnum.ExplanationText),
                Tooltip = info.GetPropertyValue(FormFieldPropertyEnum.FieldDescription)
            };

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