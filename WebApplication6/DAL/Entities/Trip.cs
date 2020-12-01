using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication6.DAL.Entities
{
    public class Trip
    {
        public int id { get; set; }
        public double distance { get; set; }
        public double speed { get; set; }
        public double maxSpeed { get; set; }
        public double minSpeed { get; set; }
        public DateTime moveStart { get; set; }
        public DateTime moveEnd { get; set; }
        public List<Point> passedRoute { get; set; }
        public int transportId { get; set; }
        public bool created { get; set; }
    }
}
