using System.Linq;
using System.Web;
using System.Web.Mvc;
using True.Kentico.Forms.Infrastructure;

namespace True.Kentico.Forms.Html.Extensions
{
    public static partial class KenticoFormHelperExtensions
    {
        public static IHtmlString SubmitButton(this KenticoForm html, string submitText, object htmlAttributes = null)
        {
            var tag = new MultiLevelTag("button");
            tag.Attributes.Add("type", "submit");
            tag.Attributes.Add("data-submit", null);
            tag.AddCssClass("button");
            tag.SetInnerText(submitText);

            if (htmlAttributes != null)
            {
                var customAttributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
                if (customAttributes != null)
                {
                    customAttributes.ToList().ForEach(item => tag.Attributes.Add(item.Key, item.Value.ToString()));
                }
            }

            return MvcHtmlString.Create(tag.ToString());
        }
    }
}
