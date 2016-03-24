namespace True.Kentico.Forms.Forms.FormParts
{
    public class Notification : INotification
    {
        public string Sender { get; set; }
        public string Recipients { get; set; }
        public string Subject { get; set; }
        public string Template { get; set; }
        public bool AttachUploadedDocuments { get; set; }
    }
}