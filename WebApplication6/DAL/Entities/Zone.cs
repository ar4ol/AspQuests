using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication6.DAL.Entities
{
    public class Zone
    {
        public int Id { get; set; }

        public Quest Quest { get; set; }

        public string Name { get; set; }

        public int CountPeople { get; set; }
    }
}
