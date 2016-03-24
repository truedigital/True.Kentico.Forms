namespace True.Kentico.Forms.Forms.FormParts
{
    public interface IAutoresponder
    {
        string Sender { get; set; }
        string Subject { get; set; }
        string Template { get; set; }
    }
}