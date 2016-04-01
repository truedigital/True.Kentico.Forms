using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using CMS.Helpers;
using True.Kentico.Forms.Forms.FormParts;
using True.Kentico.Forms.Html.ExtraAttributes;
using True.Kentico.Forms.Html.Renderers;
using CompareAttribute = System.ComponentModel.DataAnnotations.CompareAttribute;

namespace True.Kentico.Forms.Html.Extensions
{
    public static partial class KenticoFormHelperExtensions
    {
        public static IHtmlString EmailFor<TModel, TControl>(this KenticoForm<TModel> html, TControl control) where TControl : IControl
            where TModel : IForm
        {
            return EmailFor<TModel, TControl>(html, control, new DefaultEmailControlRenderer());
        }

        public static IHtmlString EmailFor<TModel, TControl>(this KenticoForm<TModel> html, TControl control, IControlRenderer renderer) where TControl : IControl
            where TModel : IForm
        {
            var renderedControl = renderer.Render(control);

            return MvcHtmlString.Create(renderedControl);
        }
    }
}
