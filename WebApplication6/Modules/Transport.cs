using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication6.DAL.Entities
{
    public class Transport
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Year { get; set; }

        public string FuelType { get; set; }

        public double FuelConsumption { get; set; } 

        public int TripId { get; set; }

        public int UserId { get; set; }
        
    }
}
