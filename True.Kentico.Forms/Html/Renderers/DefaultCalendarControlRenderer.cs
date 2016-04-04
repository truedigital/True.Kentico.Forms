using System;
using True.Kentico.Forms.Forms.FormParts;

namespace True.Kentico.Forms.Html.Renderers
{
    internal class DefaultCalendarControlRenderer : IControlRenderer
    {
        public string Render(IControl control)
        {
            //var item = (MemberExpression)expression.Body;
            var id = control.Name;

            ////var dispAttr = GetAttribute<DisplayAttribute>(item);
            ////var displayName = dispAttr != null ? dispAttr.Name : item.Member.Name;

            ////var reqAttr = GetAttribute<RequiredAttribute>(item);
            ////var helpTextAttr = GetAttribute<HelpTextAttribute>(item);

            var div = new MultiLevelTag("div");
            div.AddCssClass("form-inner");

            var input = new MultiLevelTag("input");
            input.Attributes.Add("id", id);
            input.Attributes.Add("name", id);
            input.Attributes.Add("type", "text");
            input.AddCssClass("datepicker");

            //if (reqAttr != null)
            //{
            //    input.Attributes.Add("required", null);
            //    input.Attributes.Add("data-msg-required", $"{displayName} is required");
            //}

            div.Add(input);

            if (!String.IsNullOrWhiteSpace(control.ExplanationText))
            {
                var helpTextDiv = new MultiLevelTag("div");
                helpTextDiv.AddCssClass("form-help");
                helpTextDiv.InnerHtml = control.ExplanationText;
                div.Add(helpTextDiv);
            }
            if (!String.IsNullOrWhiteSpace(control.Tooltip))
            {
                input.Attributes.Add("title", control.Tooltip);
            }

            return div.ToString();
        }
    }
}