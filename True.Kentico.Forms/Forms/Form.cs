using System;
using System.Collections.Generic;
using System.Linq;

namespace True.KenticoForms.Forms
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

        public IControl Find(string name)
        {
            return Controls.FirstOrDefault(p => string.Equals(p.Name, name, StringComparison.OrdinalIgnoreCase)) ?? new Control();
        }
    }
}
