using System;
using System.Web.Mvc;
using CMS.Base;
using True.Kentico.Forms.Forms.FormParts;

namespace True.Kentico.Forms.Html.Renderers
{
    internal class DefaultCalendarControlRenderer : BaseControlRenderer
    {
        public override string Render(IControl control, object htmlAttributes)
        {
            var id = control.Name;

            var displayName = !string.IsNullOrEmpty(control.Label) ? control.Label : control.Name;

            var div = new MultiLevelTag("div");
            div.AddCssClass("form-inner");

            var input = new MultiLevelTag("input");
            input.Attributes.Add("id", id);
            input.Attributes.Add("name", id);
            input.Attributes.Add("type", "text");
            input.Attributes.Add("readonly", null);
            CustomHtml(input, htmlAttributes);

            if (!String.IsNullOrEmpty(control.DefaultValue))
                input.Attributes.Add("value", control.DefaultValue.ToDateTime(DateTime.Now, "en-GB").ToString("dd/MM/yyyy"));

            input.AddCssClass("datepicker");

            IsRequired(control, input, displayName);

            div.Add(input);

            ExplanationText(control, div);
            ToolTip(control, input);

            return div.ToString();
        }

        public override string Render(IControl control)
        {
            return Render(control, null);
        }
    }
}