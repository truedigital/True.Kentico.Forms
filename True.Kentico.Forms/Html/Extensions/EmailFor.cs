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
        public static IHtmlString EmailFor(this KenticoForm html, IForm model, string controlName, object htmlAttributes)
        {
            var renderer = ControlRendererRegistrar.Resolve(ControlType.Email);
            var control = model.Controls.FirstOrDefault(ctrl => ctrl.Name.Equals(controlName, StringComparison.OrdinalIgnoreCase));
            return MvcHtmlString.Create(renderer.Render(control, htmlAttributes));
        }

        public static IHtmlString EmailFor<TControl>(this KenticoForm html, TControl control) where TControl : IControl
        {
            return EmailFor<TControl>(html, control, ControlRendererRegistrar.Resolve(ControlType.Email));
        }

        public static IHtmlString EmailFor<TControl>(this KenticoForm html, TControl control, IControlRenderer renderer) where TControl : IControl
        {
            var renderedControl = renderer.Render(control);

            return MvcHtmlString.Create(renderedControl);
        }

        public static IHtmlString EmailFor(this KenticoForm html, IForm model, string controlName)
        {
            var control = model.Controls.FirstOrDefault(ctrl => ctrl.Name.Equals(controlName, StringComparison.OrdinalIgnoreCase));

            return control != null ?
                CalendarFor(html, control, ControlRendererRegistrar.Resolve(ControlType.Email))
                : MvcHtmlString.Create("");
        }

        public static IHtmlString EmailFor(this KenticoForm html, IForm model, string controlName, IControlRenderer customRenderer)
        {
            var control = model.Controls.FirstOrDefault(ctrl => ctrl.Name.Equals(controlName, StringComparison.OrdinalIgnoreCase));
            var renderedControl = customRenderer.Render(control);
            return MvcHtmlString.Create(renderedControl);
        }
    }
}
