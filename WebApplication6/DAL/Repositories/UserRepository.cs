using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication6.DAL.Interfaces;
using WebApplication6.DAL.Entities;
using WebApplication6.EF;

namespace WebApplication6.DAL.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private ApplicationContext _db;

        public UserRepository(ApplicationContext applicationContext)
        {
            _db = applicationContext;
        }

        public IEnumerable<User> GetAll()
        {
            return _db.Users;
        }

        public User Get(int id)
        {
            return _db.Users.Find(id);
        }

        public void Create(User item)
        {
            _db.Users.Add(item);
        }

        public void Update(User item)
        {
            _db.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void Delete(int id)
        {
            User t = _db.Users.Find(id);
            if (t != null)
                _db.Users.Remove(t);
        }
    }
}
