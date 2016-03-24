using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Web.Mvc;

namespace True.Kentico.Forms.Html
{
	internal class MultiLevelTag: TagBuilder
	{
		public IEnumerable<MultiLevelTag> InnerTags => new ReadOnlyCollection<MultiLevelTag>(_innerTags);

		private readonly IList<MultiLevelTag> _innerTags = new List<MultiLevelTag>();

		public MultiLevelTag(string tagName) : base(tagName)
    {
		}

		public void Add(MultiLevelTag tag)
		{
			if (tag == null)
				throw new ArgumentNullException(nameof(tag));

			_innerTags.Add(tag);
		}

		public override string ToString()
		{
			var sb = new StringBuilder();

			foreach (var tag in _innerTags)
				sb.Append(tag);

			if (_innerTags.Count > 0)
				InnerHtml = sb.ToString();

			return base.ToString();
		}
	}
}
