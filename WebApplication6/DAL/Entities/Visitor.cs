using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication6.DAL.Entities
{
    public class Visitor
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public int QuestId { get; set; }

        public string CompletedRoute { get; set; }
    }
}
