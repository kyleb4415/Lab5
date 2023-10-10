using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Lab5MusicAPI
{
    public class Lifespan
    {
        public string Begin { get; set; }
        public string End { get; set; }

        public Lifespan()
        {
        }

        public Lifespan(string begin, string end)
        {
            Begin = begin;
            End = end;
        }

        public override string ToString()
        {
            return $"\tBegin date: {Begin}\n" +
                $"\tEnd date: {End}";

        }
    }
}
