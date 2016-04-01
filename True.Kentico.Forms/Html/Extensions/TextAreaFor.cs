using System.Web;
using System.Web.Mvc;
using True.Kentico.Forms.Forms.FormParts;
using True.Kentico.Forms.Html.Renderers;

namespace True.Kentico.Forms.Html.Extensions
{
    public static partial class KenticoFormHelperExtensions
    {
        public static IHtmlString TextAreaFor<TModel>(this KenticoForm<TModel> html, IControl control)
            where TModel : IForm
        {
            return TextAreaFor<TModel>(html, control, new DefaultTextAreaControlRenderer());
        }

        public static IHtmlString TextAreaFor<TModel>(this KenticoForm<TModel> html, IControl control, IControlRenderer customRenderer)
            where TModel : IForm
        {

            var renderedControl = customRenderer.Render(control);

            return MvcHtmlString.Create(renderedControl.ToString());

        }
    }
}
