namespace True.Kentico.Forms.Html
{
	public class KenticoForm<T>
	{
		public T Model { get; set; }

		public KenticoForm(T model)
		{
			Model = model;
		}
	}
}
