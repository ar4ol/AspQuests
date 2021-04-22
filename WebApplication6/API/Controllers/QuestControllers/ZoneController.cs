using Microsoft.AspNetCore.Mvc;
using WebApplication6.EF;
using WebApplication6.BLL.Services;
using WebApplication6.ViewModels;
using WebApplication6.DAL.Interfaces;
using System.Threading.Tasks;
using WebApplication6.DAL.Entities;
using System.Linq;
using System.Text.Json;
using System.Collections.Generic;
using System;

namespace WebApplication6.API.Controllers.QuestControllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ZoneController : ControllerBase
    {
        private IUnitOfWork _db;

        public ZoneController(IUnitOfWork unitOfWork)
        {
            _db = unitOfWork;
        }

        [Route("getlistzones")]
        [HttpPost]
        public async Task<IEnumerable<Zone>> GetZones([FromBody] QuestVM questModel)
        {

            List<Zone> list = _db.Zones.GetAll().ToList().FindAll(x => x.QuestId == questModel.Id);
            return list;
        }

        [Route("create")]
        [HttpPost]
        public async Task<ActionResult<Zone>> Create([FromBody] ZoneVM zoneModel)
        {
            Zone zone = new Zone();
            zone.Name = zoneModel.Name;
            zone.QuestId = zoneModel.QuestId;
            zone.CountPeople = 0;
            _db.Zones.Create(zone);
            _db.Save();
            zone = _db.Zones.GetAll().Last();
            return zone;
        }

        [Route("change")]
        [HttpPatch]
        public async Task<ActionResult<Zone>> Change([FromBody] ZoneVM zoneModel)
        {
            Zone zone = _db.Zones.GetAll().ToList().Find(x => x.Id == zoneModel.Id);
            zone.Name = zoneModel.Name;
            zone.CountPeople = zoneModel.CountPeople;
            _db.Zones.Update(zone);
            _db.Save();
            return zone;
        }

        [Route("delete")]
        [HttpPost]
        public async Task<ActionResult<Zone>> Delete([FromBody] UserDeleteVM udModel)
        {
            Zone zone = _db.Zones.GetAll().ToList().Find(x => x.Id == udModel.ZoneId);
            _db.Zones.Delete(zone.Id);
            _db.Save();
            return zone;
        }

        [Route("visitors/{zoneId}")]
        [HttpGet]
        public async Task<ActionResult<string>> Visitors(int zoneId)
        {
            Zone zone = _db.Zones.Get(zoneId);
            object response;
            response = new {
                message = "Visitors in zone counted!",
                count = zone.CountPeople
            };
            return JsonSerializer.Serialize(response);
        }
    }
}
