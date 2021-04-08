using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication6.DAL.Entities
{
    public class Excercise
    {
        public int Id { get; set; }

        public int ZoneId { get; set; }

        public string Name { get; set; }

        public string Description { get; set;  }

    }
}
