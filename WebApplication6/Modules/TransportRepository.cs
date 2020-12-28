using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication6.DAL.Interfaces;
using WebApplication6.DAL.Entities;
using WebApplication6.EF;

namespace WebApplication6.DAL.Repositories
{
    public class TransportRepository : IRepository<Transport>
    {
        private ApplicationContext _db;

        public TransportRepository(ApplicationContext applicationContext)
        {
            _db = applicationContext;
        }

        public IEnumerable<Transport> GetAll()
        {
            return _db.Transports;
        }

        public Transport Get(int id)
        {
            return _db.Transports.Find(id);
        }

        public void Create(Transport item)
        {
            _db.Transports.Add(item);
        }

        public void Update(Transport item)
        {
            _db.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void Delete(int id)
        {
            Transport t = _db.Transports.Find(id);
            if (t != null)
                _db.Transports.Remove(t);
        }
    }
}
