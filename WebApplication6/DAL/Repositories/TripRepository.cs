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
        private ApplicationContext _db;

        public TripRepository(ApplicationContext applicationContext)
        {
            _db = applicationContext;
        }

        public IEnumerable<Trip> GetAll()
        {
            return _db.Trips;
        }

        public Trip Get(int id)
        {
            return _db.Trips.Find(id);
        }

        public void Create(Trip item)
        {
            _db.Trips.Add(item);
        }

        public void Update(Trip item)
        {
            _db.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void Delete(int id)
        {
            Trip t = _db.Trips.Find(id);
            if (t != null)
                _db.Trips.Remove(t);
        }
    }
}
