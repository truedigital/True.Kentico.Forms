using System;
using True.Kentico.Forms.Forms.FormParts;

namespace True.Kentico.Forms.Html.Renderers
{
    internal class DefaultDropDownListControlRenderer : BaseControlRenderer
    {
        public override string Render(IControl control, object htmlAttributes)
        {
            var id = control.Name;

            var displayName = !string.IsNullOrEmpty(control.Label) ? control.Label : control.Name;

            var div = new MultiLevelTag("div");
            div.AddCssClass("form-inner");

            var ddl = new MultiLevelTag("select");
            ddl.Attributes.Add("id", id);
            ddl.Attributes.Add("name", id);
            CustomHtml(ddl, htmlAttributes);

            var items = control.DefaultValues;

            foreach (var innerItem in items)
            {
                var option = new MultiLevelTag("option") { InnerHtml = innerItem.Key };
                if (innerItem.Value) option.Attributes.Add("selected", null);
                ddl.Add(option);
            }

            IsRequired(control, ddl, displayName);

            div.Add(ddl);

            ExplanationText(control, div);
            ToolTip(control, ddl);

            return div.ToString();
        }

        public override string Render(IControl control)
        {
            return Render(control, null);
        }
    }
}