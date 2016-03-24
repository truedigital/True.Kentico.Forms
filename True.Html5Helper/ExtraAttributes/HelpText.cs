using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace True.Html5Helper.ExtraAttributes
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
