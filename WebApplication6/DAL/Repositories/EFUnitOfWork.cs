using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication6.DAL.Interfaces;
using WebApplication6.DAL.Entities;
using WebApplication6.EF;


namespace WebApplication6.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private ApplicationContext _db;
        private UserRepository _userRepository;
        private QuestRepository _questRepository;
        private ZoneRepository _zoneRepository;
        private ExcerciseRepository _excerciseRepository;

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

        public IRepository<Quest> Quests {
            get {
                if (_questRepository == null)
                    _questRepository = new QuestRepository(_db);
                return _questRepository;
            }
        }

        public IRepository<Zone> Zones {
            get {
                if (_zoneRepository == null)
                    _zoneRepository = new ZoneRepository(_db);
                return _zoneRepository;
            }
        }

        public IRepository<Excercise> Excercises {
            get {
                if (_excerciseRepository == null)
                    _excerciseRepository = new ExcerciseRepository(_db);
                return _excerciseRepository;
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
