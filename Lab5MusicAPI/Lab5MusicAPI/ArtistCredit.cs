using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5MusicAPI
{

    public class ArtistCredit
    {
        public string Name { get; set; }
        public Artist artist { get; set; }

        public ArtistCredit(string name, Artist artist)
        {
            this.Name = name;
            this.artist = artist;
        }

        public override string ToString()
        {
            return $"Artist Info -----\n" +
                $"Name: {Name}\n" +
                $"Artist {artist.ToString()}\n";
        }
    }
}
