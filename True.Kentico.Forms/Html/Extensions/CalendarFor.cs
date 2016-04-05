using System.Web;
using System.Web.Mvc;
using True.Kentico.Forms.Forms.FormParts;
using True.Kentico.Forms.Html.Renderers;
using True.Kentico.Forms.Infrastructure;

namespace True.Kentico.Forms.Html.Extensions
{
	public static partial class KenticoFormHelperExtensions
	{
	    public static IHtmlString CalendarFor<TModel>(this KenticoForm<TModel> html, IControl control) where TModel : IForm
	    {
	        return CalendarFor<TModel>(html, control, ControlRendererRegistrar.ControlRenderers[ControlType.Calendar]);
	    }

	    public static IHtmlString CalendarFor<TModel>(this KenticoForm<TModel> html, IControl control, IControlRenderer customRenderer) where TModel : IForm
	    {
	        var renderedControl = customRenderer.Render(control);

			return MvcHtmlString.Create(renderedControl.ToString());
		}
	}
}
