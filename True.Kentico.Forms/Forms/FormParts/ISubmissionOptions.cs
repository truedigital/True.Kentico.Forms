namespace True.Kentico.Forms.Forms.FormParts
{
    public interface ISubmissionOptions
    {
        string DisplayText { get; set; }
        string RedirectUrl { get; set; }
        bool ClearAfterSave { get; set; }
        bool ContinueEditing { get; }
    }
}