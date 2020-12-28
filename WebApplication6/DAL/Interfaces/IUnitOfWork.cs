using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication6.DAL.Entities;

namespace WebApplication6.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<User> Users { get; }
        IRepository<Transport> Transports { get; }
        IRepository<Point> Points { get; }
        IRepository<Trip> Trips { get; }
        IRepository<Rest> Rests { get; }
        IRepository<Mark> Marks { get; }
        IRepository<Offer> Offers { get; }

        void Save();
    }
}
