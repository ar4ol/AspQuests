using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication6.DAL.Interfaces;
using WebApplication6.DAL.Entities;
using WebApplication6.EF;

namespace WebApplication6.DAL.Repositories
{
    public class PointRepository : IRepository<Point>
    {
        private ApplicationContext _db;

        public PointRepository(ApplicationContext applicationContext)
        {
            _db = applicationContext;
        }

        public IEnumerable<Point> GetAll()
        {
            return _db.Points;
        }

        public Point Get(int id)
        {
            return _db.Points.Find(id);
        }

        public void Create(Point item)
        {
            _db.Points.Add(item);
        }

        public void Update(Point item)
        {
            _db.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void Delete(int id)
        {
            Point t = _db.Points.Find(id);
            if (t != null)
                _db.Points.Remove(t);
        }
    }
}
