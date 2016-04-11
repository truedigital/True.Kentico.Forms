using System;
using System.Collections.Generic;
using CMS.FormEngine;
using True.Kentico.Forms.Forms.FormParts;

namespace True.Kentico.Forms.Html.HtmlControlFactory
{
    public class HtmlControlFactory : IHtmlControlFactory
    {
        private static readonly Dictionary<ControlType, string> ControlFactories = new Dictionary<ControlType, string>
        {
            {ControlType.Email, "EmailFor"}
        };

        public IControl Create(FormFieldInfo info)
        {
            // todo IControlFactory factory;
            //if (ControlFactories.TryGetValue(ValidationHelper.GetString(info.Settings["controlName"], string.Empty), out factory))
            //    return factory.Create(info);

            //return null;
            throw new NotImplementedException();
        }
    }
}