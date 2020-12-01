using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication6.DAL.Entities;

namespace WebApplication6.API.Model
{
    public class TripModel
    {
        public int transportId { get; set; }
        public float latitude { get; set; }
        public float longitude { get; set; }
        public int time { get; set; }
        public double distance { get; set; }
        public double speed { get; set; }
        public double maxSpeed { get; set; }
        public double minSpeed { get; set; }
        public DateTime moveStart { get; set; }
        public DateTime moveEnd { get; set; }
    }
}
