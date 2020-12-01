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
    public class GetListTransportController : ControllerBase
    {
        private IUnitOfWork _db;

        public GetListTransportController(IUnitOfWork uow)
        {
            _db = uow;
        }

        [HttpPost]
        public async Task<ActionResult<string>> GetTransports([FromBody] UserModel userModel)
        {
            int id = _db.Users.GetAll().Where(x => x.login == userModel.login).FirstOrDefault().id;
            List <Transport> transports = _db.Transports.GetAll().ToList();
            List<Transport> userTransports = new List<Transport>();
            foreach(Transport t in transports)
            {
                if(t.userId == id)
                {
                    userTransports.Add(t);
                }

            }
            return Ok(userTransports);
        }
    }
}
