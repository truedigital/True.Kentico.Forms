using CMS.OnlineForms;
using True.KenticoForms.Forms;

namespace True.KenticoForms
{
    public interface IFormFactory
    {
        IForm Create(BizFormInfo info);
    }
}