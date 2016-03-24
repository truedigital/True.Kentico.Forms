using CMS.OnlineForms;
using True.Kentico.Forms.Forms.FormParts;

namespace True.Kentico.Forms.Forms
{
    public interface IFormFactory
    {
        IForm Create(BizFormInfo info);
    }
}