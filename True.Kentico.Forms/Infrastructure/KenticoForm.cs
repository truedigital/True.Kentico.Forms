using System.Web.Mvc;

namespace True.Kentico.Forms.Infrastructure
{
	public class KenticoForm
	{
	}

    public static class KenticoHTMLExtensions
    {
        public static KenticoForm KenticoForm(this HtmlHelper helper)
        {
            return new KenticoForm();
        }
    }
}
