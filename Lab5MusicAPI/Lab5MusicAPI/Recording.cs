using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Lab5MusicAPI
{
    public class Recording
    {
        public string Id { get; set; }

        public int Score { get; set; }
        public string Title { get; set; }
        public int Length { get; set; }

        [JsonPropertyName("artist-credit")]
        public List<ArtistCredit> ArtistCredit { get; set; }

        public Recording(string id, int score, string title, int length, List<ArtistCredit> artistCredit)
        {
            Id = id;
            Score = score;
                Title = title;
            Length = length;
            this.ArtistCredit = artistCredit;

        }
        public override string ToString()
        {
            string msg = $"Id: {Id}\n" +
            $"Score: {Score}\n" +
            $"Title: {Title}\n" +
            $"Length: {Length}\n" +
            $"Artist Credit:\n";
            foreach(var artist in ArtistCredit)
            {
                msg += $"{artist.ToString()}\n";
            }
            return msg;
        }
    }
}
