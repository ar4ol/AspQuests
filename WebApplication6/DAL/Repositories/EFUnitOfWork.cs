using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication6.DAL.Interfaces;
using WebApplication6.DAL.Entities;
using WebApplication6.EF;


namespace WebApplication6.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private ApplicationContext _db;
        private UserRepository userRepository;
        private TransportRepository transportRepository;
        private PointRepository pointRepository;
        private TripRepository tripRepository;

        public EFUnitOfWork(ApplicationContext db)
        {
            _db = db;
        }
        public IRepository<User> Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(_db);
                return userRepository;
            }
        }

        public IRepository<Transport> Transports
        {
            get
            {
                if (transportRepository == null)
                    transportRepository = new TransportRepository(_db);
                return transportRepository;
            }
        }

        public IRepository<Point> Points
        {
            get
            {
                if (pointRepository == null)
                    pointRepository = new PointRepository(_db);
                return pointRepository;
            }
        }

        public IRepository<Trip> Trips
        {
            get
            {
                if (tripRepository == null)
                    tripRepository = new TripRepository(_db);
                return tripRepository;
            }
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
