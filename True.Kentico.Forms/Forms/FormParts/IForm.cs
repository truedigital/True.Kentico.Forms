using System.Collections.Generic;
namespace True.Kentico.Forms.Forms.FormParts
{
    public interface IForm
    {
        string Name { get; set; }
        string SubmitText { get; set; }
        IList<IControl> Controls { get; set; }
        IAutoresponder Autoresponder { get; set; }
        INotification Notification { get; set; }
        ISubmissionOptions SubmissionOptions { get; set; }
        bool IsValid { get; }
        IList<string> ValidationErrors { get; }
        IControl Find(string name);
    }
}