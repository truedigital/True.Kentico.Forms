using System;
using System.Collections.Generic;
using True.Kentico.Forms.Forms.FormParts;
using True.Kentico.Forms.Html.Renderers;

namespace True.Kentico.Forms.Infrastructure
{
    public static class ControlRendererRegistrar
    {
        private static Dictionary<ControlType, IControlRenderer> ControlRenderers { get; set; }

        public static void InitialiseFormControls()
        {
            ControlRenderers = new Dictionary<ControlType, IControlRenderer>
            {
                {ControlType.Calendar, new DefaultCalendarControlRenderer()},
                {ControlType.CheckBox, new DefaultCheckBoxControlRenderer()},
                {ControlType.DropDownList, new DefaultDropDownListControlRenderer()},
                {ControlType.Email, new DefaultEmailControlRenderer()},
                {ControlType.HtmlArea, new DefaultHtmlEditorControlRenderer()},
                {ControlType.MultipleChoice, new DefaultMultipleChoiceControlRenderer()},
                {ControlType.RadioButton, new DefaultRadioButtonListControlRenderer()},
                {ControlType.TextArea, new DefaultTextAreaControlRenderer()},
                {ControlType.TextBox, new DefaultTextBoxForControlRenderer()},
                {ControlType.Label, new DefaultLabelControlRenderer()}
            };
        }

        public static void RegisterCustomRenderer(ControlType controlType, IControlRenderer renderer)
        {
            if (ControlRenderers == null)
            {
                InitialiseFormControls();
            }
            ControlRenderers[controlType] = renderer;
        }

        public static IControlRenderer Resolve(ControlType controlType)
        {
            if (ControlRenderers[controlType] == null)
            {
                throw new InvalidOperationException("There is no default renderer registered for the requested control type. Please register one in the ControlRendererRegistrar");
            }
            return ControlRenderers[controlType];
        }
    }
}
