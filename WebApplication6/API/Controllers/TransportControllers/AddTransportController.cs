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
            User user = _db.Users.GetAll().ToList().Find(x => x.login == transportModel.userLogin);
            Transport transport = new Transport();
            transport.name= transportModel.name;
            transport.year = transportModel.year;
            transport.fuelType = transportModel.fuelType;
            transport.fuelConsumption = transportModel.fuelConsumption;
            transport.userId = user.id;
            _db.Transports.Create(transport);
            _db.Save();
            return Ok(transport);

        }
    }
}
