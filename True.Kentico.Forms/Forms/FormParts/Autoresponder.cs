namespace True.Kentico.Forms.Forms.FormParts
{
    public class Autoresponder : IAutoresponder
    {
        public string Sender { get; set; }
        public string Subject { get; set; }
        public string Template { get; set; }
    }
}