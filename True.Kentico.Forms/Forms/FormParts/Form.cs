using System;
using System.Collections.Generic;
using System.Linq;

namespace True.Kentico.Forms.Forms.FormParts
{
    public class Form : IForm
    {
        public Form()
        {
            Controls = new List<IControl>();
        }

        public string Name { get; set; }
        public string SubmitText { get; set; }
        public IList<IControl> Controls { get; set; }
        public IAutoresponder Autoresponder { get; set; }
        public INotification Notification { get; set; }
        public ISubmissionOptions SubmissionOptions { get; set; }
        public bool IsValid => Controls.All(ctrl => ctrl.IsValid());
        public IList<string> ValidationErrors => Controls.SelectMany(ctrl => ctrl.ValidationErrors).ToList();
        
        public IControl Find(string name)
        {
            return Controls.FirstOrDefault(p => string.Equals(p.Name, name, StringComparison.OrdinalIgnoreCase)) ?? new Control();
        }
    }
}
