using True.Kentico.Forms.Forms.FormParts;

namespace True.Kentico.Forms.Html.Renderers
{
    internal class DefaultDropDownListControlRenderer : IControlRenderer
    {
        public string Render(IControl control)
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
                ddl.Add(new MultiLevelTag("option") { InnerHtml = innerItem });

            if (control.IsRequired)
            {
                ddl.Attributes.Add("required", null);
                ddl.Attributes.Add("data-msg-required", $"{displayName} is required");
            }

            div.Add(ddl);

            //if (helpTextAttr != null)
            //{
            //    var helpTextDiv = new MultiLevelTag("div");
            //    helpTextDiv.AddCssClass("form-help");
            //    helpTextDiv.InnerHtml = helpTextAttr.HelpText;
            //    div.Add(helpTextDiv);
            //}
            return div.ToString();
        }
    }
}