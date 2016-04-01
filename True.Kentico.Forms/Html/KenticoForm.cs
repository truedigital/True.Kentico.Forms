using True.Kentico.Forms.Forms.FormParts;

namespace True.Kentico.Forms.Html
{
	public class KenticoForm<T> where T:IForm
	{
		public T Model { get; set; }

		public KenticoForm(T model)
		{
			Model = model;
		}
	}
}
