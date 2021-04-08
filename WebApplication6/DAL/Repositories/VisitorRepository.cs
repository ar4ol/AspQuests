using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication6.DAL.Interfaces;
using WebApplication6.DAL.Entities;
using WebApplication6.EF;

namespace WebApplication6.DAL.Repositories
{
    public class VisitorRepository : IRepository<Visitor>
    {
        private ApplicationContext _db;

        public VisitorRepository(ApplicationContext applicationContext)
        {
            _db = applicationContext;
        }

        public void Create(Visitor item)
        {
            _db.Visitors.Add(item);
        }

        public void Delete(int id)
        {
            Visitor t = _db.Visitors.Find(id);
            if (t != null)
                _db.Visitors.Remove(t);
        }

        public Visitor Get(int id)
        {
            return _db.Visitors.Find(id);
        }

        public IEnumerable<Visitor> GetAll()
        {
            return _db.Visitors;
        }

        public void Update(Visitor item)
        {
            _db.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }
}
