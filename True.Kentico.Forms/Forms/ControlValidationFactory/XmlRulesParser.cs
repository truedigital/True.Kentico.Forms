using System.IO;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using CMS.FormEngine;

namespace True.Kentico.Forms.Forms.ControlValidationFactory
{
    internal class XmlRulesParser
    {
        public XmlRules GetXmlRules(FieldMacroRule info)
        {
            var regex = new Regex("<rules>(.+?)</rules>");
            var match = regex.Match(info.MacroRule);
            var data = Regex.Unescape(match.Value);

            var serializer = new XmlSerializer(typeof (XmlRules));
            using (var reader = new StringReader(data))
            {
                return (XmlRules)serializer.Deserialize(reader);
            }
        }
    }
}