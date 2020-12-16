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
    public class AddTransportController : ControllerBase
    {
        private IUnitOfWork _db;

        public AddTransportController(IUnitOfWork unitOfWork)
        {
            _db = unitOfWork;
        }

        [HttpPost]
        public async Task<ActionResult<Transport>> AddTransport([FromBody] TransportModel transportModel)
        {
            User user = _db.Users.GetAll().ToList().Find(x => x.Id == transportModel.UserId);
            Transport transport = new Transport();
            transport.Name= transportModel.Name;
            transport.Year = transportModel.Year;
            transport.FuelType = transportModel.FuelType;
            transport.FuelConsumption = transportModel.FuelConsumption;
            transport.UserId = transportModel.UserId;
            _db.Transports.Create(transport);
            _db.Save();
            return Ok(transport);

        }
    }
}
