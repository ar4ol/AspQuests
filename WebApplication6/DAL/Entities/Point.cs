using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication6.DAL.Entities
{
    public class Point
    {
        public int Id { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public DateTime Time  { get; set; }

        public int TripId { get; set; }
    }
}
