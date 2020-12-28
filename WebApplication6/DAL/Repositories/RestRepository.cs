using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication6.DAL.Interfaces;
using WebApplication6.DAL.Entities;
using WebApplication6.EF;

namespace WebApplication6.DAL.Repositories
{
        public class RestRepository : IRepository<Rest>
        {
            private ApplicationContext _db;

            public RestRepository(ApplicationContext applicationContext)
            {
                _db = applicationContext;
            }

            public IEnumerable<Rest> GetAll()
            {
                return _db.Rests;
            }

            public Rest Get(int id)
            {
                return _db.Rests.Find(id);
            }

            public void Create(Rest item)
            {
                _db.Rests.Add(item);
            }

            public void Update(Rest item)
            {
                _db.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }

            public void Delete(int id)
            {
                Rest t = _db.Rests.Find(id);
                if (t != null)
                    _db.Rests.Remove(t);
            }
        }
    }
