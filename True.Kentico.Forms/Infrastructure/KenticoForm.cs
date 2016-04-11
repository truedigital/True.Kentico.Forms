using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using True.Kentico.Forms.Forms.FormParts;

namespace True.Kentico.Forms.Html
{
	public class KenticoForm
	{
	    public KenticoForm()
	    {
	        
	    }

	}

    public static class KenticoHTMLExtensions
    {
        public static KenticoForm KenticoForm(this HtmlHelper helper)
        {
            return new KenticoForm();
        }
    }
}
