using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication6.DAL.Interfaces;
using WebApplication6.DAL.Entities;
using WebApplication6.EF;

namespace WebApplication6.DAL.Repositories
{
    public class MarkRepository : IRepository<Mark>
    {
        private ApplicationContext _db;

        public MarkRepository(ApplicationContext applicationContext)
        {
            _db = applicationContext;
        }

        public IEnumerable<Mark> GetAll()
        {
            return _db.Marks;
        }

        public Mark Get(int id)
        {
            return _db.Marks.Find(id);
        }

        public void Create(Mark item)
        {
            _db.Marks.Add(item);
        }

        public void Update(Mark item)
        {
            _db.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void Delete(int id)
        {
            Mark t = _db.Marks.Find(id);
            if (t != null)
                _db.Marks.Remove(t);
        }
    }
}
