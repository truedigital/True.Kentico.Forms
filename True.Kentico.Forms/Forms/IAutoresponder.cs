namespace True.KenticoForms.Forms
{
    public interface IAutoresponder
    {
        string Sender { get; set; }
        string Subject { get; set; }
        string Template { get; set; }
    }
}