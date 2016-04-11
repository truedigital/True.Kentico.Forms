﻿using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Mvc;
using True.Kentico.Forms.Forms.FormParts;

namespace True.Kentico.Forms.Html.Extensions
{
    public static partial class KenticoFormHelperExtensions
    {
        public static IHtmlString RenderFormControls<TControls>(this KenticoForm model, TControls controls) where TControls : IList<IControl>
        {
            var result = new StringBuilder();

            foreach (var control in controls)
            {
                if (control.Type == ControlType.Email)
                {
                    result.AppendLine(string.Concat(
                        "<div class=\"form-row\">",
                        model.LabelFor(control).ToHtmlString(),
                        model.EmailFor(control).ToHtmlString(),
                        "</div>"
                        ));
                }

                if (control.Type == ControlType.TextBox)
                {
                    result.AppendLine(string.Concat(
                        "<div class=\"form-row\">",
                        model.LabelFor(control).ToHtmlString(),
                        model.TextBoxFor(control).ToHtmlString(),
                        "</div>"
                        ));
                }

                if (control.Type == ControlType.MultipleChoice)
                {
                    result.AppendLine(string.Concat(
                        "<div class=\"form-row\">",
                        model.LabelFor(control).ToHtmlString(),
                        model.MultipleChoiceFor(control).ToHtmlString(),
                        "</div>"
                        ));
                }

                if (control.Type == ControlType.DropDownList)
                {
                    result.AppendLine(string.Concat(
                        "<div class=\"form-row\">",
                        model.LabelFor(control).ToHtmlString(),
                        model.DropDownListFor(control).ToHtmlString(),
                        "</div>"
                        ));
                }

                if (control.Type == ControlType.RadioButton)
                {
                    result.AppendLine(string.Concat(
                        "<div class=\"form-row\">",
                        model.LabelFor(control).ToHtmlString(),
                        model.RadioButtonFor(control).ToHtmlString(),
                        "</div>"
                        ));
                }

                if (control.Type == ControlType.CheckBox)
                {
                    result.AppendLine(string.Concat(
                        "<div class=\"form-row\">",
                        model.LabelFor(control).ToHtmlString(),
                        model.CheckboxFor(control).ToHtmlString(),
                        "</div>"
                        ));
                }

                if (control.Type == ControlType.TextArea)
                {
                    result.AppendLine(string.Concat(
                        "<div class=\"form-row\">",
                        model.LabelFor(control).ToHtmlString(),
                        model.TextAreaFor(control).ToHtmlString(),
                        "</div>"
                        ));
                }

                // todo other types
                // todo this should use strategy-factory
            }

            return MvcHtmlString.Create(result.ToString());
        }
    }
}