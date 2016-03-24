namespace True.KenticoForms.ControlValidationFactory
{
    internal interface IControlValidationTypeProvider
    {
        ValidationType GetValidationType(string rule);
    }
}