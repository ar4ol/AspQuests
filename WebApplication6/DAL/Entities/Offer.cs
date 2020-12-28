using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication6.DAL.Entities
{
    public class Offer
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int RestId { get; set; }

        public string Date { get; set; }
    }
}
