using System.Web;
using System.Web.Mvc;
using True.Kentico.Forms.Forms.FormParts;
using True.Kentico.Forms.Html.Renderers;

namespace True.Kentico.Forms.Html.Extensions
{
    public static partial class KenticoFormHelperExtensions
    {
        public static IHtmlString DropDownListFor<TModel, TControl>(this KenticoForm<TModel> html, TControl control) where TControl : IControl
            where TModel : IForm
        {
            return DropDownListFor<TModel, TControl>(html, control, new DefaultDropDownListControlRenderer());
        }

        public static IHtmlString DropDownListFor<TModel, TControl>(this KenticoForm<TModel> html, TControl control, IControlRenderer customRenderer) where TControl : IControl
            where TModel : IForm
        {

            var renderedControl = customRenderer.Render(control);

            return MvcHtmlString.Create(renderedControl.ToString());
        }
    }
}
