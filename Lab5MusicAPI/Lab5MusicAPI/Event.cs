using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Lab5MusicAPI
{
    public class Event
    {
        public string Id { get; set; }
        public int Score { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        [JsonPropertyName("life-span")]
        public Lifespan Lifespan { get; set; }
        public Event(string id, int score, string name, string type, Lifespan lifespan)
        {
            this.Id = id;
            this.Score = score;
            this.Name = name;
            this.Type = type;
            this.Lifespan = lifespan;

        }

        public override string ToString()
        {
            string msg = $"Name: {Name}\n" +
                $"Type: {Type}\n" +
                $"Lifespan: \n{Lifespan}";
            return msg;
        }
    }
}
