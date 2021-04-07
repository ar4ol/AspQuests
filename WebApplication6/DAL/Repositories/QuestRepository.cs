using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication6.DAL.Interfaces;
using WebApplication6.DAL.Entities;
using WebApplication6.EF;

namespace WebApplication6.DAL.Repositories
{
    public class QuestRepository : IRepository<Quest>
    {
        private ApplicationContext _db;

        public QuestRepository(ApplicationContext applicationContext)
        {
            _db = applicationContext;
        }

        public IEnumerable<Quest> GetAll()
        {
            return _db.Quests;
        }

        public Quest Get(int id)
        {
            return _db.Quests.Find(id);
        }

        public void Create(Quest item)
        {
            _db.Quests.Add(item);
        }

        public void Update(Quest item)
        {
            _db.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void Delete(int id)
        {
            Quest t = _db.Quests.Find(id);
            if (t != null)
                _db.Quests.Remove(t);
        }
    }
}
