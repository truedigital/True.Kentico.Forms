namespace True.Kentico.Forms.Html
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
