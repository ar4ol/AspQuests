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
        private ApplicationContext Db;

        public UserRepository(ApplicationContext applicationContext)
        {
            Db = applicationContext;
        }

        public IEnumerable<User> GetAll()
        {
            return Db.Users;
        }

        public User Get(int id)
        {
            return Db.Users.Find(id);
        }

        public void Create(User item)
        {
            Db.Users.Add(item);
        }

        public void Update(User item)
        {
            Db.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void Delete(int id)
        {
            User t = Db.Users.Find(id);
            if (t != null)
                Db.Users.Remove(t);
        }
    }
}
