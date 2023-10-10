using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5MusicAPI
{
    public class GetRecording
    {
        public string Created { get; set; }
        public int Count { get; set; }
        public List<Recording> Recordings { get; set; }
        public GetRecording() { }
        public GetRecording(string created, int count, List<Recording> recordings)
        {
            this.Created = created;
            Count = count;
            this.Recordings = recordings;
        }
        public override string ToString()
        {
            return $"{Created}, {Count}, {Recordings[0].ToString()}";
        }
    }
}
