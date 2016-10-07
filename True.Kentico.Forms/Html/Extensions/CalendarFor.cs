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
        public static IHtmlString CalendarFor(this KenticoForm html, IForm model, string controlName, object htmlAttributes)
        {
            var renderer = ControlRendererRegistrar.Resolve(ControlType.Calendar);
            var control = model.Controls.FirstOrDefault(ctrl => ctrl.Name.Equals(controlName, StringComparison.OrdinalIgnoreCase));
            return MvcHtmlString.Create(renderer.Render(control, htmlAttributes));
        }

        public static IHtmlString CalendarFor(this KenticoForm html, IControl control) 
	    {
	        return CalendarFor(html, control, ControlRendererRegistrar.Resolve(ControlType.Calendar));
	    }

	    public static IHtmlString CalendarFor(this KenticoForm html, IControl control, IControlRenderer customRenderer) 
	    {
	        var renderedControl = customRenderer.Render(control);
			return MvcHtmlString.Create(renderedControl);
		}

        public static IHtmlString CalendarFor(this KenticoForm html, IForm model, string controlName, string classes)
        {
            var control = model.Controls.FirstOrDefault(ctrl => ctrl.Name.Equals(controlName, StringComparison.OrdinalIgnoreCase));

            return control != null ?
                CalendarFor(html, control, ControlRendererRegistrar.Resolve(ControlType.Calendar))
                : MvcHtmlString.Create("");
        }

        public static IHtmlString CalendarFor(this KenticoForm html, IForm model, string controlName, IControlRenderer customRenderer)
        {
            var control = model.Controls.FirstOrDefault(ctrl => ctrl.Name.Equals(controlName, StringComparison.OrdinalIgnoreCase));
            var renderedControl = customRenderer.Render(control);
            return MvcHtmlString.Create(renderedControl);
        }
    }
}
