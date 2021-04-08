using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication6.DAL.Entities;

namespace WebApplication6.API.ViewModels
{
    public class QuestVM
    {
        public int Id { get; set; }

        public User User { get; set; }

        public string Name { get; set; }

        public string Route { get; set; }
    }
}
