using System;
using True.Kentico.Forms.Forms.FormParts;

namespace True.Kentico.Forms.Html.Renderers
{
    internal class DefaultDropDownListControlRenderer : BaseControlRenderer
    {
        public override string Render(IControl control)
        {
            var id = control.Name;

            var displayName = !string.IsNullOrEmpty(control.Label) ? control.Label : control.Name;

            //var helpTextAttr = GetAttribute<HelpTextAttribute>(item);

            var div = new MultiLevelTag("div");
            div.AddCssClass("form-inner");

            var ddl = new MultiLevelTag("select");
            ddl.Attributes.Add("id", id);
            ddl.Attributes.Add("name", id);

            var items = control.DefaultValues;

            foreach (var innerItem in items)
            {
                var option = new MultiLevelTag("option") { InnerHtml = innerItem.Key };
                if (innerItem.Value) option.Attributes.Add("selected", null);
                ddl.Add(option);
            }
            
            IsRequired(control, ddl, displayName);
            
            div.Add(ddl);

            if (!String.IsNullOrWhiteSpace(control.ExplanationText))
            {
                var helpTextDiv = new MultiLevelTag("div");
                helpTextDiv.AddCssClass("form-help");
                helpTextDiv.InnerHtml = control.ExplanationText;
                div.Add(helpTextDiv);
            }
            if (!String.IsNullOrWhiteSpace(control.Tooltip))
            {
                ddl.Attributes.Add("title", control.Tooltip);
            }
            return div.ToString();
        }
    }
}