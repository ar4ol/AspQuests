using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication6.DAL.Entities
{
    public class Transport
    {
        public int id { get; set; }
        public string name { get; set; }
        public int year { get; set; }
        public string fuelType { get; set; }
        public double fuelConsumption { get; set; }  
        public int tripId { get; set; }
        public int userId { get; set; }
        
    }
}
