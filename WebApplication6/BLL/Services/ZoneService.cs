using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication6.EF;
using WebApplication6.BLL.Services;
using WebApplication6.DAL.Entities;
using WebApplication6.ViewModels;
using WebApplication6.DAL.Interfaces;
using WebApplication6.BLL.Interfaces;

namespace WebApplication6.BLL.Services
{
    public class ZoneService : IZoneService
    {
        public IUnitOfWork _db;

        public ZoneService(IUnitOfWork unitOfWork)
        {
            _db = unitOfWork;
        }

        public Visitor EnterZone(int visitorId, int zoneId)
        {
            Visitor visitor = _db.Visitors.Get(visitorId);
            visitor.ZoneId = zoneId;
            _db.Visitors.Update(visitor);
            _db.Save();
            ZoneCounter(zoneId);
            return visitor;
            
        }

        public void ZoneCounter(int zoneId)
        {
            Zone zone = _db.Zones.Get(zoneId);
            zone.CountPeople++;
            _db.Zones.Update(zone);
            _db.Save();
        }
    }
}
