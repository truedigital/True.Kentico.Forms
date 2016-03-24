using System.Collections.Generic;

namespace True.KenticoForms.Forms
{
    public interface IForm
    {
        string Name { get; set; }
        string SubmitText { get; set; }
        IList<IControl> Controls { get; set; }
        IAutoresponder Autoresponder { get; set; }
        INotification Notification { get; set; }

        IControl Find(string name);
    }
}