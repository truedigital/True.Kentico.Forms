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
        public static IHtmlString UploadFor<TControl>(this KenticoForm html, TControl control) where TControl : IControl
        {
            return UploadFor(html, control, ControlRendererRegistrar.Resolve(ControlType.UploadFile));
        }

        public static IHtmlString UploadFor<TControl>(this KenticoForm html, TControl control, IControlRenderer customRenderer) where TControl : IControl
        {
            var renderedControl = customRenderer.Render(control);

            return MvcHtmlString.Create(renderedControl);
        }

        public static IHtmlString UploadFor(this KenticoForm html, IForm model, string controlName)
        {
            var control = model.Controls.FirstOrDefault(ctrl => ctrl.Name.Equals(controlName, StringComparison.OrdinalIgnoreCase));

            return control != null ?
                CalendarFor(html, control, ControlRendererRegistrar.Resolve(ControlType.UploadFile))
                : MvcHtmlString.Create("");
        }

        public static IHtmlString UploadFor(this KenticoForm html, IForm model, string controlName, IControlRenderer customRenderer)
        {
            var control = model.Controls.FirstOrDefault(ctrl => ctrl.Name.Equals(controlName, StringComparison.OrdinalIgnoreCase));
            var renderedControl = customRenderer.Render(control);
            return MvcHtmlString.Create(renderedControl);
        }
    }
}
