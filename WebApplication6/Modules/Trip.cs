using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication6.DAL.Entities
{
    public class Trip
    {
        public int Id { get; set; }

        public double Distance { get; set; }

        public double Speed { get; set; }

        public double MaxSpeed { get; set; }

        public double MinSpeed { get; set; }

        public DateTime MoveStart { get; set; }

        public DateTime MoveEnd { get; set; }

        public int TransportId { get; set; }

        public bool Created { get; set; }
    }
}
