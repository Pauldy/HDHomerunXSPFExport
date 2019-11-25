using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HDHomerunXSPFExport
{
    [XmlRoot(ElementName = "playlist", Namespace = "http://xspf.org/ns/0/")]
    public partial class PlayList
    {
        [XmlAttribute(AttributeName = "version")]
        public string version { get; set; }
        public TrackList trackList { get; set; }
    }

    public partial class TrackList
    {
        [XmlElement(ElementName = "track")]
        public Track[] tracks { get; set; }
    }
    public partial class Track
    {
        public string title { get; set; }
        public string location { get; set; }
    }
}
