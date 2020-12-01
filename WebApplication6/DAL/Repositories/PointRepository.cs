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
        private ApplicationContext Db;

        public PointRepository(ApplicationContext applicationContext)
        {
            Db = applicationContext;
        }

        public IEnumerable<Point> GetAll()
        {
            return Db.Points;
        }

        public Point Get(int id)
        {
            return Db.Points.Find(id);
        }

        public void Create(Point item)
        {
            Db.Points.Add(item);
        }

        public void Update(Point item)
        {
            Db.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void Delete(int id)
        {
            Point t = Db.Points.Find(id);
            if (t != null)
                Db.Points.Remove(t);
        }
    }
}
