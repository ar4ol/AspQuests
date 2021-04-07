using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication6.DAL.Interfaces;
using WebApplication6.DAL.Entities;
using WebApplication6.EF;


namespace WebApplication6.DAL.Repositories
{
    public class ZoneRepository : IRepository<Zone>
    {
        private ApplicationContext _db;

        public ZoneRepository(ApplicationContext applicationContext)
        {
            _db = applicationContext;
        }

        public IEnumerable<Zone> GetAll()
        {
            return _db.Zones;
        }

        public Zone Get(int id)
        {
            return _db.Zones.Find(id);
        }

        public void Create(Zone item)
        {
            _db.Zones.Add(item);
        }

        public void Update(Zone item)
        {
            _db.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void Delete(int id)
        {
            Zone t = _db.Zones.Find(id);
            if (t != null)
                _db.Zones.Remove(t);
        }
    }
}
