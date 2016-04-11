using System.Web;
using System.Web.Mvc;
using True.Kentico.Forms.Forms.FormParts;
using True.Kentico.Forms.Html.Renderers;
using True.Kentico.Forms.Infrastructure;

namespace True.Kentico.Forms.Html.Extensions
{
    public static partial class KenticoFormHelperExtensions
    {
        public static IHtmlString TextBoxFor(this KenticoForm html, IControl control)
            
        {
            return TextBoxFor(html, control, ControlRendererRegistrar.Resolve(ControlType.TextBox));
        }

        public static IHtmlString TextBoxFor(this KenticoForm html, IControl control, IControlRenderer customRenderer)
            
        {
            var renderedControl = customRenderer.Render(control);

            return MvcHtmlString.Create(renderedControl);
        }
    }
}
