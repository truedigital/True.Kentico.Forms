using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace True.Kentico.Forms.Forms.Data
{
    public class FormEntry
    {
        public FormEntry()
        {
            FormValues = new Dictionary<string, string>();
        }
        public int ID { get; set; }
        public Dictionary<string, string> FormValues { get; set; }
    }
}
