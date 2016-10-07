using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using True.Kentico.Forms.Forms.FormParts;
using True.Kentico.Forms.Html.Renderers;
using True.Kentico.Forms.Infrastructure;

namespace True.Kentico.Forms.Html.Extensions
{
    public static partial class KenticoFormHelperExtensions
    {
        public static IHtmlString RadioButtonFor(this KenticoForm html, IForm model, string controlName, object htmlAttributes)
        {
            var renderer = ControlRendererRegistrar.Resolve(ControlType.RadioButton);
            var control = model.Controls.FirstOrDefault(ctrl => ctrl.Name.Equals(controlName, StringComparison.OrdinalIgnoreCase));
            return MvcHtmlString.Create(renderer.Render(control, htmlAttributes));
        }

        public static IHtmlString RadioButtonFor<TControl>(this KenticoForm html, TControl control) where TControl : IControl

        {
            return RadioButtonFor<TControl>(html, control, ControlRendererRegistrar.Resolve(ControlType.RadioButton));
        }

        public static IHtmlString RadioButtonFor<TControl>(this KenticoForm html, TControl control, IControlRenderer customRenderer) where TControl : IControl

        {
            var renderedControl = customRenderer.Render(control);

            return MvcHtmlString.Create(renderedControl.ToString());
        }

        public static IHtmlString RadioButtonFor(this KenticoForm html, IForm model, string controlName)
        {
            var control = model.Controls.FirstOrDefault(ctrl => ctrl.Name.Equals(controlName, StringComparison.OrdinalIgnoreCase));

            return control != null ?
                CalendarFor(html, control, ControlRendererRegistrar.Resolve(ControlType.RadioButton))
                : MvcHtmlString.Create("");
        }

        public static IHtmlString RadioButtonFor(this KenticoForm html, IForm model, string controlName, IControlRenderer customRenderer)
        {
            var control = model.Controls.FirstOrDefault(ctrl => ctrl.Name.Equals(controlName, StringComparison.OrdinalIgnoreCase));
            var renderedControl = customRenderer.Render(control);
            return MvcHtmlString.Create(renderedControl);
        }
    }
}
