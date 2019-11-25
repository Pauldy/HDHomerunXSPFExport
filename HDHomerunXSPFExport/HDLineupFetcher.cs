using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace HDHomerunXSPFExport
{
    public partial class HDLineupFetcher : Form
    {
        public HDLineupFetcher()
        {
            InitializeComponent();
        }

        private void buildButton_Click(object sender, EventArgs e)
        {
            string addressForat = "http://{0}/lineup.xml";
            WebClient client = new WebClient();
            var bytes = client.DownloadData(string.Format(addressForat, ipTextBox.Text));
            XmlSerializer lineupSerializer = new XmlSerializer(typeof(Lineup));
            MemoryStream ms = new MemoryStream(bytes);
            var lineup = (Lineup)lineupSerializer.Deserialize(ms);

            List<Track> tracks = new List<Track>();
            foreach(var program in lineup.Programs)
            {
                tracks.Add(new Track()
                {
                    location = program.URL,
                    title = string.Format("({0}) {1}{2}", program.GuideNumber, program.GuideName, program.HD == "1" ? " HD" : ""),
                });
            }
            var playlist = new PlayList()
            {
                version = "1",
                trackList = new TrackList()
                {
                    tracks = tracks.ToArray()
                }
            };

            XmlSerializer playListSerializer = new XmlSerializer(typeof(PlayList));
            ms = new MemoryStream();
            playListSerializer.Serialize(ms, playlist);
            SaveFileDialog sfd = new SaveFileDialog
            {
                AddExtension = true,
                Filter = "Playlist File (*.xspf)|*.xspf",
                DefaultExt = "xspf"
            };
            if(sfd.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllBytes(sfd.FileName, ms.ToArray());
            }
        }
    }
}
