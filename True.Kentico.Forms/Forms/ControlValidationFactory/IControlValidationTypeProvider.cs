namespace True.Kentico.Forms.Forms.ControlValidationFactory
{
    internal interface IControlValidationTypeProvider
    {
        ValidationType GetValidationType(string rule);
    }
}