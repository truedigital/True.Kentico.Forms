﻿using System;
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