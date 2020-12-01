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
        private ApplicationContext Db;

        public TransportRepository(ApplicationContext applicationContext)
        {
            Db = applicationContext;
        }

        public IEnumerable<Transport> GetAll()
        {
            return Db.Transports;
        }

        public Transport Get(int id)
        {
            return Db.Transports.Find(id);
        }

        public void Create(Transport item)
        {
            Db.Transports.Add(item);
        }

        public void Update(Transport item)
        {
            Db.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void Delete(int id)
        {
            Transport t = Db.Transports.Find(id);
            if (t != null)
                Db.Transports.Remove(t);
        }
    }
}
