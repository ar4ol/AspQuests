using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication6.DAL.Interfaces;
using WebApplication6.DAL.Entities;
using WebApplication6.EF;

namespace WebApplication6.DAL.Repositories
{
    public class TripRepository : IRepository<Trip>
    {
        private ApplicationContext Db;

        public TripRepository(ApplicationContext applicationContext)
        {
            Db = applicationContext;
        }

        public IEnumerable<Trip> GetAll()
        {
            return Db.Trips;
        }

        public Trip Get(int id)
        {
            return Db.Trips.Find(id);
        }

        public void Create(Trip item)
        {
            Db.Trips.Add(item);
        }

        public void Update(Trip item)
        {
            Db.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void Delete(int id)
        {
            Trip t = Db.Trips.Find(id);
            if (t != null)
                Db.Trips.Remove(t);
        }
    }
}
