using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication6.DAL.Interfaces;
using WebApplication6.DAL.Entities;
using WebApplication6.EF;

namespace WebApplication6.DAL.Repositories
{
    public class ExcerciseRepository
    {
        private ApplicationContext _db;

        public ExcerciseRepository(ApplicationContext applicationContext)
        {
            _db = applicationContext;
        }

        public IEnumerable<Excercise> GetAll()
        {
            return _db.Excercises;
        }

        public Excercise Get(int id)
        {
            return _db.Excercises.Find(id);
        }

        public void Create(Excercise item)
        {
            _db.Excercises.Add(item);
        }

        public void Update(Excercise item)
        {
            _db.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void Delete(int id)
        {
            Excercise t = _db.Excercises.Find(id);
            if (t != null)
                _db.Excercises.Remove(t);
        }
    }
}
