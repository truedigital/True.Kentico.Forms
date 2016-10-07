using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using True.Kentico.Forms.Forms.FormParts;

namespace True.Kentico.Forms.Html.Renderers
{
    public class DefaultListBoxControlRenderer : BaseControlRenderer
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
            ddl.Attributes.Add("multiple", null);
            CustomHtml(ddl, htmlAttributes);

            var items = control.DefaultValues;

            foreach (var innerItem in items)
            {
                ddl.Add(new MultiLevelTag("option")
                {
                    InnerHtml = innerItem.Key,
                    Attributes = { new KeyValuePair<string, string>("selected", innerItem.Value.ToString()) }
                });
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
