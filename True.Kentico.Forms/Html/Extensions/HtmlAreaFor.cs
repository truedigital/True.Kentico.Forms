﻿using System.Web;
using System.Web.Mvc;
using True.Kentico.Forms.Forms.FormParts;
using True.Kentico.Forms.Html.Renderers;
using True.Kentico.Forms.Infrastructure;

namespace True.Kentico.Forms.Html.Extensions
{
    public static partial class KenticoFormHelperExtensions
    {
        public static IHtmlString HtmlAreaFor(this KenticoForm html, IControl control)
        {
            return HtmlAreaFor(html, control, ControlRendererRegistrar.Resolve(ControlType.TextArea));
        }

        public static IHtmlString HtmlAreaFor(this KenticoForm html, IControl control, IControlRenderer customRenderer)
        {
            var renderedControl = customRenderer.Render(control);

            return MvcHtmlString.Create(renderedControl);

        }
    }
}