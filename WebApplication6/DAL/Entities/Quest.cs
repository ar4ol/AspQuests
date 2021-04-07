using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication6.DAL.Entities
{
    public class Quest
    {
        public int Id { get; set; }

        public User User { get; set; }

        public string Name { get; set; }

        public List<int> Route { get; set; }
    }
}
