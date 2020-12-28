using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication6.DAL.Entities;

namespace WebApplication6.EF
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Transport> Transports { get; set; }
        public DbSet<Point> Points { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Rest> Rests { get; set; }
        public DbSet<Mark> Marks { get; set; }
        public DbSet<Offer> Offers { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
