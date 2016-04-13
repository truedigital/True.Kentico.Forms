using System.Web;
using System.Web.Mvc;
using True.Kentico.Forms.Infrastructure;

namespace True.Kentico.Forms.Html.Extensions
{
    public static partial class KenticoFormHelperExtensions
    {
        public static IHtmlString SubmitButton(this KenticoForm html, string submitText)
        {
            var tag = new MultiLevelTag("button");
            tag.Attributes.Add("type", "submit");
            tag.Attributes.Add("data-submit", null);
            tag.AddCssClass("button");
            tag.SetInnerText(submitText);

            return MvcHtmlString.Create(tag.ToString());
        }
    }
}
