using System.Xml.Serialization;

namespace True.KenticoForms.ControlValidationFactory
{
    [XmlRoot("rules")]
    public class XmlRules
    {
        [XmlElement("r")]
        public XmlRule Rule { get; set; }
    }

    public class XmlRule
    {
        [XmlAttribute("pos")]
        public int Position { get; set; }

        [XmlAttribute("par")]
        public string Parameter { get; set; }

        [XmlAttribute("n")]
        public string Type { get; set; }

        [XmlElement("p")]
        public XmlProperties Properties { get; set; }
    }

    public class XmlProperties
    {
        [XmlAttribute("n")]
        public string Type { get; set; }

        [XmlElement("t")]
        public string T { get; set; }

        [XmlElement("v")]
        public string V { get; set; }

        [XmlElement("r")]
        public string R { get; set; }

        [XmlElement("d")]
        public string D { get; set; }

        [XmlElement("vt")]
        public string Vt { get; set; }

        [XmlElement("tv")]
        public string Tv { get; set; }
    }
}