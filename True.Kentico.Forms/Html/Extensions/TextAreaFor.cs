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
        public static IHtmlString TextAreaFor(this KenticoForm html, IControl control)
            
        {
            return TextAreaFor(html, control, ControlRendererRegistrar.Resolve(ControlType.TextArea));
        }

        public static IHtmlString TextAreaFor(this KenticoForm html, IControl control, IControlRenderer customRenderer)
        {
            var renderedControl = customRenderer.Render(control);

            return MvcHtmlString.Create(renderedControl.ToString());

        }

        public static IHtmlString TextAreaFor(this KenticoForm html, IForm model, string controlName)
        {
            var control = model.Controls.FirstOrDefault(ctrl => ctrl.Name.Equals(controlName, StringComparison.OrdinalIgnoreCase));

            return control != null ?
                TextAreaFor(html, control, ControlRendererRegistrar.Resolve(ControlType.TextArea))
                : MvcHtmlString.Create("");
        }

        public static IHtmlString TextAreaFor(this KenticoForm html, IForm model, string controlName, object htmlAttributes)
        {        
            var renderer = ControlRendererRegistrar.Resolve(ControlType.TextArea);
            var control = model.Controls.FirstOrDefault(ctrl => ctrl.Name.Equals(controlName, StringComparison.OrdinalIgnoreCase));
            return MvcHtmlString.Create(renderer.Render(control, htmlAttributes));
        }

        public static IHtmlString TextAreaFor(this KenticoForm html, IForm model, string controlName, IControlRenderer customRenderer)
        {
            var control = model.Controls.FirstOrDefault(ctrl => ctrl.Name.Equals(controlName, StringComparison.OrdinalIgnoreCase));
            var renderedControl = customRenderer.Render(control);
            return MvcHtmlString.Create(renderedControl);
        }
    }
}
