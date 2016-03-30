using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using True.Kentico.Forms.Forms.FormParts;
using True.Kentico.Forms.Html.ExtraAttributes;

namespace True.Kentico.Forms.Html.Extensions
{
    public static partial class KenticoFormHelperExtensions
    {
        public static IHtmlString MultipleChoiceFor<TModel, TControl>(this KenticoForm<TModel> html, TControl control) where TControl : IControl
        {
            var id = control.Name;

            //var helpTextAttr = GetAttribute<HelpTextAttribute>(item);

            var div = new MultiLevelTag("div");
            div.AddCssClass("form-inner");

            var items = control.DefaultValues;

            var count = 1;
            foreach (var innerItem in items)
            {
                var input = new MultiLevelTag("input");
                input.Attributes.Add("id", $"{id}_{count}");
                input.Attributes.Add("name", $"{id}_{count}");
                input.Attributes.Add("type", "checkbox");

                var label = new MultiLevelTag("label");
                label.Attributes.Add("for", $"{id}_{count}");
                label.SetInnerText(innerItem);

                var checkboxDiv = new MultiLevelTag("div");
                checkboxDiv.AddCssClass("form-checkbox");

                checkboxDiv.Add(input);
                checkboxDiv.Add(label);

                div.Add(checkboxDiv);
                count++;
            }

            if (control.IsRequired)
            {
                div.Attributes.Add("required", null);
                div.Attributes.Add("data-msg-required", $"{control.Label} is required");
            }

            //if (helpTextAttr != null)
            //{
            //    var helpTextDiv = new MultiLevelTag("div");
            //    helpTextDiv.AddCssClass("form-help");
            //    helpTextDiv.InnerHtml = helpTextAttr.HelpText;
            //    div.Add(helpTextDiv);
            //}

            return MvcHtmlString.Create(div.ToString());
        }
    }
}
