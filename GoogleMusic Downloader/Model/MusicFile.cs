using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoogleMusic_Downloader.Model
{
    public class MusicFile
    {
        public string Id { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public string Title { get; set; }
        public override string ToString()
        {
            return Artist + " - " + Title;
        }
    }
}
