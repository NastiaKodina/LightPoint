using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi2.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
        public virtual ICollection<Event> Events { get; set; }

        public Location()
        {
            Events = new HashSet<Event>();
        }
    }
}
