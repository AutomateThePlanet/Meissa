using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Meissa.Plugins.Protractor.Model
{
    [XmlRoot(ElementName = "failure")]
    public class Failure
    {
        [XmlElement(ElementName = "message")]
        public string Message { get; set; }
        [XmlElement(ElementName = "stack-trace")]
        public string Stacktrace { get; set; }
    }
}
