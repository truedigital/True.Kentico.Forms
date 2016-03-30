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

        public static IHtmlString RenderFormControls<TModel, TControls>(this KenticoForm<TModel> model, TControls controls) where TControls : IList<IControl>
        {
            var result = new StringBuilder();

            foreach (var control in controls)
            {
                if (control.Type == ControlType.Email)
                    result.AppendLine(model.EmailFor(control).ToHtmlString());
                if (control.Type == ControlType.TextBox)
                    result.AppendLine(model.TextBoxFor(control).ToHtmlString());

                // todo other types ... also, this should use strategy-factory
            }

            return MvcHtmlString.Create(result.ToString());
        }
    }
}