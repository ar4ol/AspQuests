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

namespace WebApplication6.BLL.Interfaces
{
    interface IZoneService
    {
        public Visitor EnterZone(int visitorId, int zoneId);

        public void ZoneCounter(int zoneId);
    }
}
