using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace True.Html5Helper
{
	public class Html5<T>
	{
		public T Model { get; set; }

		public Html5(T model)
		{
			Model = model;
		}
	}
}
