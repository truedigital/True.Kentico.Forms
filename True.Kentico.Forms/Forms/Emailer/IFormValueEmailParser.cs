using System.Collections.Generic;
using True.Kentico.Forms.Forms.FormParts;

namespace True.Kentico.Forms.Forms.Emailer
{
    public interface IFormValueEmailParser
    {
        string Parse(string input, IEnumerable<IControl> controls);
    }
}