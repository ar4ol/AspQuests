using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication6.DAL.Entities
{
    public class Point
    {
        public int id { get; set; }
        public float latitude { get; set; }
        public float longitude { get; set; }
        public int time  { get; set; }
        public int tripId { get; set; }
    }
}
