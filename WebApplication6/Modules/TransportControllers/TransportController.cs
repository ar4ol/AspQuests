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
        public async Task<ActionResult<Transport>> TransportInfo(int id)
        {
            Transport transport = _db.Transports.Get(id);
            return transport;
        }

        [Route("delete")]
        [HttpPost]
        public async Task<ActionResult<Transport>> DeleteTransport([FromBody] TransportModel transportModel)
        {
            _db.Transports.Delete(transportModel.Id);
            _db.Save();
            return Ok(transportModel.Id);
        }

        [Route("change")]
        [HttpPost]
        public async Task<ActionResult<Transport>> ChangeTransport([FromBody] TransportModel transportModel)
        {
            Transport transport = _db.Transports.Get(transportModel.Id);
            transport.Name = transportModel.Name;
            transport.Year = transportModel.Year;
            transport.FuelConsumption = transportModel.FuelConsumption;
            transport.FuelType = transportModel.FuelType;
            _db.Transports.Update(transport);
            _db.Save();
            return Ok();
        }

    }

}
