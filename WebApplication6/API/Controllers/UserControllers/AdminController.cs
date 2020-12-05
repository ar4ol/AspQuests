using Microsoft.AspNetCore.Mvc;
using WebApplication6.EF;
using WebApplication6.BLL.Services;
using WebApplication6.API.Model;
using WebApplication6.DAL.Interfaces;
using System.Threading.Tasks;
using WebApplication6.DAL.Entities;
using System.Linq;
using System.Text.Json;
using System.Collections.Generic;

namespace WebApplication6.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private IUnitOfWork _db;

        public AdminController(IUnitOfWork unitOfWork)
        {
            _db = unitOfWork;
        }

        [Route("all")]
        [HttpPost]
        public async Task<ICollection<User>> GetAll([FromBody] UserModel userModel)
        {
            User user = _db.Users.GetAll().ToList().Find(x => x.id == userModel.id);
            if(user.role == "admin")
            {
                return _db.Users.GetAll().ToList();
            }
            return (ICollection<User>) new NotFoundObjectResult(user);
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<ActionResult<User>> ShowProfile(int id)
        {
            User user = _db.Users.GetAll().ToList().Find(x => x.id == id);
            return new ObjectResult(user);
        }

        [Route("{id}")]
        [HttpPost]
        public async Task<ActionResult<User>> ChangeProfile([FromBody]UserModel userModel)
        {
            User user = _db.Users.GetAll().ToList().Find(x => x.id == userModel.id);
            user.login = userModel.login;
            user.name = userModel.name;
            user.surname = userModel.surname;
            user.password = userModel.password;
            _db.Users.Update(user);
            _db.Save();
            return Ok(user);
        }
    }
}

