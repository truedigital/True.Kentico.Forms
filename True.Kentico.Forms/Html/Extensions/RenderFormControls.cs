using System;
using System.Collections.Generic;
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
                switch (control.Type)
                {
                    case ControlType.Calendar:
                        result.AppendLine(string.Concat("<div class=\"form-row\">", model.LabelFor(control).ToHtmlString(), model.CalendarFor(control).ToHtmlString(), "</div>"));
                        break;
                    case ControlType.CheckBox:
                        result.AppendLine(string.Concat("<div class=\"form-row\">", model.LabelFor(control).ToHtmlString(), model.CheckboxFor(control).ToHtmlString(), "</div>"));
                        break;
                    case ControlType.DropDownList:
                        result.AppendLine(string.Concat("<div class=\"form-row\">", model.LabelFor(control).ToHtmlString(), model.DropDownListFor(control).ToHtmlString(), "</div>"));
                        break;
                    case ControlType.Country:
                        throw new NotImplementedException("Not done yet");
                    case ControlType.Email:
                        result.AppendLine(string.Concat("<div class=\"form-row\">", model.LabelFor(control).ToHtmlString(), model.EmailFor(control).ToHtmlString(), "</div>"));
                        break;
                    case ControlType.HtmlArea:
                        result.AppendLine(string.Concat("<div class=\"form-row\">", model.LabelFor(control).ToHtmlString(), model.HtmlAreaFor(control).ToHtmlString(), "</div>"));
                        break;
                    case ControlType.Label:
                        result.AppendLine(model.LabelFor(control).ToHtmlString());
                        break;
                    case ControlType.ListBox:
                        result.AppendLine(string.Concat("<div class=\"form-row\">", model.LabelFor(control).ToHtmlString(), model.ListBoxFor(control).ToHtmlString(), "</div>"));
                        break;
                    case ControlType.MultipleChoice:
                        result.AppendLine(string.Concat("<div class=\"form-row\">", model.LabelFor(control).ToHtmlString(), model.MultipleChoiceFor(control).ToHtmlString(), "</div>"));
                        break;
                    case ControlType.RadioButton:
                        result.AppendLine(string.Concat("<div class=\"form-row\">", model.LabelFor(control).ToHtmlString(), model.RadioButtonFor(control).ToHtmlString(), "</div>"));
                        break;
                    case ControlType.TextBox:
                        result.AppendLine(string.Concat("<div class=\"form-row\">", model.LabelFor(control).ToHtmlString(), model.TextBoxFor(control).ToHtmlString(), "</div>"));
                        break;
                    case ControlType.TextArea:
                        result.AppendLine(string.Concat("<div class=\"form-row\">", model.LabelFor(control).ToHtmlString(), model.TextAreaFor(control).ToHtmlString(), "</div>"));
                        break;
                    case ControlType.UploadFile:
                        result.AppendLine(string.Concat("<div class=\"form-row\">", model.LabelFor(control).ToHtmlString(), model.UploadFor(control).ToHtmlString(), "</div>"));
                        break;
                    case ControlType.Unknown:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            return MvcHtmlString.Create(result.ToString());
        }
    }
}