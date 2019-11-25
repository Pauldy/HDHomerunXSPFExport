using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HDHomerunXSPFExport

{
    [XmlRoot(ElementName = "Lineup")]
    public partial class Lineup
    {
        [XmlElement(ElementName = "Program")]
        public Programs[] Programs { get; set; }
    }
    public partial class Programs
    {
        public string GuideNumber { get; set; }
        public string GuideName { get; set; }
        public string VideoCodec { get; set; }
        public string AudioCodec { get; set; }
        public string HD { get; set; }
        public string URL { get; set; }
    }
}
