﻿using System;
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
        public static IHtmlString TextBoxFor(this KenticoForm html, IForm model, string controlName, object htmlAttributes)
        {
            var renderer = ControlRendererRegistrar.Resolve(ControlType.TextBox);
            var control = model.Controls.FirstOrDefault(ctrl => ctrl.Name.Equals(controlName, StringComparison.OrdinalIgnoreCase));
            return MvcHtmlString.Create(renderer.Render(control, htmlAttributes));            
        }

        public static IHtmlString TextBoxFor(this KenticoForm html, IControl control)
            
        {
            return TextBoxFor(html, control, ControlRendererRegistrar.Resolve(ControlType.TextBox));
        }

        public static IHtmlString TextBoxFor(this KenticoForm html, IControl control, IControlRenderer customRenderer)
            
        {
            var renderedControl = customRenderer.Render(control);

            return MvcHtmlString.Create(renderedControl);
        }

        public static IHtmlString TextBoxFor(this KenticoForm html, IForm model, string controlName)
        {
            var control = model.Controls.FirstOrDefault(ctrl => ctrl.Name.Equals(controlName, StringComparison.OrdinalIgnoreCase));

            return control != null ?
                TextBoxFor(html, control, ControlRendererRegistrar.Resolve(ControlType.TextBox))
                : MvcHtmlString.Create("");
        }

        public static IHtmlString TextBoxFor(this KenticoForm html, IForm model, string controlName, IControlRenderer customRenderer)
        {
            var control = model.Controls.FirstOrDefault(ctrl => ctrl.Name.Equals(controlName, StringComparison.OrdinalIgnoreCase));
            var renderedControl = customRenderer.Render(control);
            return MvcHtmlString.Create(renderedControl);
        }
    }
}
