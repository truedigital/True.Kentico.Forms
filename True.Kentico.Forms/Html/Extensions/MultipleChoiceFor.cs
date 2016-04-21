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
        public static IHtmlString MultipleChoiceFor<TControl>(this KenticoForm html, TControl control) where TControl : IControl
            
        {
            return MultipleChoiceFor<TControl>(html, control, ControlRendererRegistrar.Resolve(ControlType.MultipleChoice));
        }

        public static IHtmlString MultipleChoiceFor<TControl>(this KenticoForm html, TControl control, IControlRenderer customRenderer) where TControl : IControl
            
        {
             var renderedControl = customRenderer.Render(control);

            return MvcHtmlString.Create(renderedControl.ToString());
        }

        public static IHtmlString MultipleChoiceFor(this KenticoForm html, IForm model, string controlName)
        {
            var control = model.Controls.FirstOrDefault(ctrl => ctrl.Name.Equals(controlName, StringComparison.OrdinalIgnoreCase));

            return control != null ?
                CalendarFor(html, control, ControlRendererRegistrar.Resolve(ControlType.MultipleChoice))
                : MvcHtmlString.Create("");
        }

        public static IHtmlString MultipleChoiceFor(this KenticoForm html, IForm model, string controlName, IControlRenderer customRenderer)
        {
            var control = model.Controls.FirstOrDefault(ctrl => ctrl.Name.Equals(controlName, StringComparison.OrdinalIgnoreCase));
            var renderedControl = customRenderer.Render(control);
            return MvcHtmlString.Create(renderedControl);
        }
    }
}
