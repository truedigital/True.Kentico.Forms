using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using True.Kentico.Forms.Forms.FormParts;
using True.Kentico.Forms.Html.ExtraAttributes;
using True.Kentico.Forms.Html.Renderers;

namespace True.Kentico.Forms.Html.Extensions
{
	public static partial class KenticoFormHelperExtensions
	{
	    public static IHtmlString RadioButtonFor<TModel, TControl>(this KenticoForm<TModel> html, TControl control) where TControl : IControl
	        where TModel : IForm
	    {
	        return RadioButtonFor<TModel, TControl>(html, control, new DefaultRadioButtonListControlRenderer());
	    }

	    public static IHtmlString RadioButtonFor<TModel, TControl>(this KenticoForm<TModel> html, TControl control, IControlRenderer customRenderer) where TControl : IControl
            where TModel : IForm
        {
             var renderedControl = customRenderer.Render(control);

            return MvcHtmlString.Create(renderedControl.ToString());
        }        
	}
}
