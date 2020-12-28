using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication6.DAL.Entities
{
    public class Rest
    {
        public int Id { get; set; }

        public string Type { get; set; }
        
        public string Name { get; set; }

        public string Location { get; set; }

        public int Cost { get; set; }

        public double AvMark { get; set; }

        public int CountMarks { get; set; }
    }
}
