using System;

namespace True.Kentico.Forms.Html.ExtraAttributes
{
	public class HelpTextAttribute: Attribute
	{
		public string HelpText { get; set; }

		public HelpTextAttribute(string helpText)
		{
			HelpText = helpText;
		}
	}
}
