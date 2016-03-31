namespace True.Kentico.Forms.Forms.FormParts
{
    public class SubmissionOptions : ISubmissionOptions
    {
        public string DisplayText { get; set; }
        public string RedirectUrl { get; set; }
        public bool ClearAfterSave { get; set; }
        public bool ContinueEditing => string.IsNullOrEmpty(DisplayText) &
                                       string.IsNullOrEmpty(RedirectUrl) &
                                       !ClearAfterSave;
    }
}