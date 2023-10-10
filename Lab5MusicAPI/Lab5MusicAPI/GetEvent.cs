using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5MusicAPI
{
    public class GetEvent
    {
        public List<Event> Events { get; set; }

        public GetEvent() 
        {
            Events = new List<Event>(); 
        }

        public GetEvent(List<Event> events)
        {
            Events = events;
        }

        public override string ToString()
        {
            foreach(var e in Events)
            {
                return e.ToString();
            }
            return string.Empty;
        }
    }
}
