using True.Kentico.Forms.Forms.FormParts;

namespace True.Kentico.Forms.Forms
{
    public interface IFormRepository
    {
        void Submit(IForm form);
        IForm GetForm(string formName);
    }
}