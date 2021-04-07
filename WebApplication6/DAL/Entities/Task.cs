using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication6.DAL.Entities
{
    public class Task
    {
        public int Id { get; set; }

        public Zone Zone { get; set; }

        public string Name { get; set; }

        public string Description { get; set;  }

        public bool isCompleted { get; set; }
    }
}
