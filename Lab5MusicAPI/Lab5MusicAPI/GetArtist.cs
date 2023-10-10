using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5MusicAPI
{
    public class GetArtist
    {
        public List<Artist> Artists { get; set; }

        public GetArtist() 
        {
            Artists = new List<Artist>();
        }
        public GetArtist(List<Artist> artists)
        {
            foreach(var a in artists)
            {
                Artists.Add(a);
            }
        }

        public override string ToString()

        {
            foreach(var artist in Artists) 
            {
                return artist.ToString();
            }

            return string.Empty;
        }
    }
}
