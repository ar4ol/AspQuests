using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication6.DAL.Interfaces;
using WebApplication6.DAL.Entities;
using WebApplication6.EF;

namespace WebApplication6.DAL.Repositories
{
    public class OfferRepository : IRepository<Offer>
    {
        private ApplicationContext _db;

        public OfferRepository(ApplicationContext applicationContext)
        {
            _db = applicationContext;
        }

        public IEnumerable<Offer> GetAll()
        {
            return _db.Offers;
        }

        public Offer Get(int id)
        {
            return _db.Offers.Find(id);
        }

        public void Create(Offer item)
        {
            _db.Offers.Add(item);
        }

        public void Update(Offer item)
        {
            _db.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void Delete(int id)
        {
            Offer t = _db.Offers.Find(id);
            if (t != null)
                _db.Offers.Remove(t);
        }
    }
}
