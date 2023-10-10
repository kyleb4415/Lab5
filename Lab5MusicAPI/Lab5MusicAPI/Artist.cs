using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5MusicAPI
{
    public class Artist
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }

        public Artist(string id, string name, string country)
        {
            Id = id;
            Name = name;
            Country = country;
        }

        public override string ToString()
        {
            return $"Name: {Name}\n" +
                $"Country: {Country}";
        }
    }
}
