using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication6.DAL.Entities;

namespace WebApplication6.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<User> Users { get; }
        IRepository<Quest> Quests { get; }
        IRepository<Zone> Zones { get; }
        IRepository<Excercise> Excercises { get; }
        IRepository<Visitor> Visitors { get; }

        void Save();
    }
}
