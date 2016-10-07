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
        public static IHtmlString LabelFor(this KenticoForm html, IForm model, string controlName, object htmlAttributes)
        {
            var renderer = ControlRendererRegistrar.Resolve(ControlType.Label);
            var control = model.Controls.FirstOrDefault(ctrl => ctrl.Name.Equals(controlName, StringComparison.OrdinalIgnoreCase));
            return MvcHtmlString.Create(renderer.Render(control, htmlAttributes));
        }

        public static IHtmlString LabelFor(this KenticoForm html, IControl control)
        {
            return LabelFor(html, control, ControlRendererRegistrar.Resolve(ControlType.Label));
        }

        public static IHtmlString LabelFor(this KenticoForm html, IForm model, string controlName)
        {
            var control = model.Controls.FirstOrDefault(ctrl => ctrl.Name.Equals(controlName, StringComparison.OrdinalIgnoreCase));

            return control != null ?
                LabelFor(html, control, ControlRendererRegistrar.Resolve(ControlType.Label))
                : MvcHtmlString.Create("");
        }

        public static IHtmlString LabelFor<TControl>(this KenticoForm html, TControl control, IControlRenderer customRenderer) where TControl : IControl
        {
            var renderedControl = customRenderer.Render(control);
            return MvcHtmlString.Create(renderedControl);
        }

        public static IHtmlString LabelFor(this KenticoForm html, IForm model, string controlName, IControlRenderer customRenderer)
        {
            var control = model.Controls.FirstOrDefault(ctrl => ctrl.Name.Equals(controlName, StringComparison.OrdinalIgnoreCase));
            var renderedControl = customRenderer.Render(control);
            return MvcHtmlString.Create(renderedControl);
        }
    }
}
