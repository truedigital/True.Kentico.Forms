using System.Web;
using System.Web.Mvc;
using True.Kentico.Forms.Forms.FormParts;
using True.Kentico.Forms.Html.Renderers;
using True.Kentico.Forms.Infrastructure;

namespace True.Kentico.Forms.Html.Extensions
{
    public static partial class KenticoFormHelperExtensions
    {
        public static IHtmlString CheckboxFor<TControl>(this KenticoForm html, TControl control)
            where TControl : IControl 
            
        {
            return CheckboxFor<TControl>(html, control, ControlRendererRegistrar.Resolve(ControlType.CheckBox));
        }

        public static IHtmlString CheckboxFor<TControl>(this KenticoForm html, TControl control, IControlRenderer customRenderer)
            where TControl : IControl 
            
        {

            var renderedControl = customRenderer.Render(control);

            return MvcHtmlString.Create(renderedControl.ToString());
        }
    }
}
