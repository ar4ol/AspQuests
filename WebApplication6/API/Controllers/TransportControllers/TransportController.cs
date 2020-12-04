using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication6.API.Model;
using WebApplication6.DAL.Entities;
using WebApplication6.DAL.Interfaces;

namespace WebApplication6.API.Controllers
{

    [Route("api/[controller]")]
    public class TransportController : ControllerBase
    {
        private IUnitOfWork _db;

        public TransportController(IUnitOfWork unitOfWork)
        {
            _db = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<Transport>> TransportInfo([FromBody] TransportModel transportModel)
        {
            Transport transport = _db.Transports.Get(transportModel.id);
            return transport;
        }

        [Route("delete")]
        [HttpPost]
        public async Task<ActionResult<Transport>> DeleteTransport([FromBody] TransportModel transportModel)
        {
            _db.Transports.Delete(transportModel.id);
            _db.Save();
            return Ok(transportModel.id);
        }

        [Route("change")]
        [HttpPost]
        public async Task<ActionResult<Transport>> ChangeTransport([FromBody] TransportModel transportModel)
        {
            Transport transport = _db.Transports.Get(transportModel.id);
            transport.name = transportModel.name;
            transport.year = transportModel.year;
            transport.fuelConsumption = transportModel.fuelConsumption;
            transport.fuelType = transportModel.fuelType;
            _db.Transports.Update(transport);
            _db.Save();
            return Ok();
        }

    }

}
