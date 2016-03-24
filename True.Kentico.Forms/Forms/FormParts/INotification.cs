namespace True.Kentico.Forms.Forms.FormParts
{
    public interface INotification
    {
        string Sender { get; set; }
        string Recipients { get; set; }
        string Subject { get; set; }
        string Template { get; set; }
        bool AttachUploadedDocuments { get; set; }
    }
}