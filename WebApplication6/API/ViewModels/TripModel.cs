using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication6.DAL.Entities;

namespace WebApplication6.API.Model
{
    public class TripModel
    {
        public int TransportId { get; set; }

        public float Latitude { get; set; }

        public float Longitude { get; set; }

        public int Time { get; set; }

        public double Distance { get; set; }

        public double Speed { get; set; }

        public double MaxSpeed { get; set; }

        public double MinSpeed { get; set; }

        public DateTime MoveStart { get; set; }

        public DateTime MoveEnd { get; set; }
    }
}
