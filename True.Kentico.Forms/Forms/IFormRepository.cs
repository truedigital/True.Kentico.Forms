using System.Collections.Generic;
using True.Kentico.Forms.Forms.Data;
using True.Kentico.Forms.Forms.FormParts;

namespace True.Kentico.Forms.Forms
{
    public interface IFormRepository
    {
        void Submit(IForm form);
        IForm GetForm(string formName);
        List<FormEntry> GetFormEntries(string formName);
        void InsertFormEntry(string formName, FormEntry entry);
        void UpdateFormEntry(string formName, int itemID, string fieldToUpdate, object newValue);
    }
}