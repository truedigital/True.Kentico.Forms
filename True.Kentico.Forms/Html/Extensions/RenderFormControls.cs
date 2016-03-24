using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;
using True.Kentico.Forms.Forms.FormParts;

namespace True.Kentico.Forms.Html.Extensions
{
    public static partial class KenticoFormHelperExtensions
    {
        public static IHtmlString RenderFormControls<TModel>(this KenticoForm<TModel> model) where TModel : IForm
        {
            var result = new StringBuilder();

            foreach (var control in model.Model.Controls)
            {
                result.AppendLine($"<input type=\"email\" value=\"{control.Label}\" />");
            }

            return MvcHtmlString.Create(result.ToString());
        }

        public static IHtmlString RenderFormControls<TModel, TProperty>(this KenticoForm<TModel> model, TProperty expression) where TProperty : IList<IControl>
        {
            var result = new StringBuilder();
            
            foreach (var control in expression)
            {
                // this should render its control type
                result.AppendLine($"<input type=\"email\" value=\"{control.Label}\" />");
            }

            return MvcHtmlString.Create(result.ToString());
        }
    }
}