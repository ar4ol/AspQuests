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
        private UserRepository _userRepository;
        private TransportRepository _transportRepository;
        private PointRepository _pointRepository;
        private TripRepository _tripRepository;
        private RestRepository _restRepository;
        private MarkRepository _markRepository;
        private OfferRepository _offerRepository;

        public EFUnitOfWork(ApplicationContext db)
        {
            _db = db;
        }

        public IRepository<User> Users
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new UserRepository(_db);
                return _userRepository;
            }
        }

        public IRepository<Rest> Rests {
            get {
                if (_restRepository == null)
                    _restRepository = new RestRepository(_db);
                return _restRepository;
            }
        }

        public IRepository<Mark> Marks {
            get {
                if (_markRepository == null)
                    _markRepository = new MarkRepository(_db);
                return _markRepository;
            }
        }

        public IRepository<Offer> Offers {
            get {
                if (_offerRepository == null)
                    _offerRepository = new OfferRepository(_db);
                return _offerRepository;
            }
        }

        public IRepository<Transport> Transports
        {
            get
            {
                if (_transportRepository == null)
                    _transportRepository = new TransportRepository(_db);
                return _transportRepository;
            }
        }

        public IRepository<Point> Points
        {
            get
            {
                if (_pointRepository == null)
                    _pointRepository = new PointRepository(_db);
                return _pointRepository;
            }
        }

        public IRepository<Trip> Trips
        {
            get
            {
                if (_tripRepository == null)
                    _tripRepository = new TripRepository(_db);
                return _tripRepository;
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
