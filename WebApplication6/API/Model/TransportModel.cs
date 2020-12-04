using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication6.API.Model
{
    public class TransportModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public int year { get; set; }
        public string fuelType { get; set; }
        public double fuelConsumption { get; set; }
        public bool inUsing { get; set; }
        public int tripId { get; set; }
        public int userId { get; set; }
    }
}
