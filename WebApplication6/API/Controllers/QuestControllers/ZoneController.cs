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

        [Route("create")]
        [HttpPost]
        public async Task<ActionResult<Zone>> Create([FromBody] ZoneVM zoneModel)
        {
            Zone zone = new Zone();
            zone.Name = zoneModel.Name;
            zone.Quest = zoneModel.Quest;
            zone.CountPeople = 0;
            _db.Zones.Create(zone);
            zone = _db.Zones.GetAll().Last();
            return zone;
        }

        [Route("change")]
        [HttpPatch]
        public async Task<ActionResult<Zone>> Change([FromBody] ZoneVM zoneModel)
        {
            Zone zone = _db.Zones.GetAll().ToList().Find(x => x.Id == zoneModel.Id);
            zone.CountPeople = zoneModel.CountPeople;
            _db.Zones.Update(zone);
            return zone;
        }

        [Route("delete")]
        [HttpDelete]
        public async Task<ActionResult<Zone>> Delete([FromBody] UserDeleteVM udModel)
        {
            Zone zone = _db.Zones.GetAll().ToList().Find(x => x.Id == udModel.ZoneId);
            User user = zone.Quest.User;
            if (user.Id == udModel.UserId)
            {
                _db.Zones.Delete(zone.Id);
                return zone;
            }
            else
            {
                return new Zone();
            }
        }
    }
}
