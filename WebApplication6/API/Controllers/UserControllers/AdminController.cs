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
        public async Task<ICollection<User>> GetAll([FromBody] UserVM UserVM)
        {
            User user = _db.Users.GetAll().ToList().Find(x => x.Id == UserVM.Id);
            if(user.Role == "admin")
            {
                return  _db.Users.GetAll().ToList();
            }
            return (ICollection<User>) new NotFoundObjectResult(user);
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<ActionResult<User>> ShowProfile(int id)
        {
            User user = _db.Users.GetAll().ToList().Find(x => x.Id == id);
            return Ok(user);
        }

        [Route("{id}")]
        [HttpPatch]
        public async Task<ActionResult<User>> ChangeProfile([FromBody]UserVM UserVM)
        {
            User user = _db.Users.GetAll().ToList().Find(x => x.Id == UserVM.Id);
            user.Login = UserVM.Login;
            user.Name = UserVM.Name;
            user.Surname = UserVM.Surname;
            user.Password = UserVM.Password;
            _db.Users.Update(user);
            _db.Save();
            return Ok(user);
        }

        [Route("deleteuser")]
        [HttpPost]
        public async Task<ActionResult> DeleteUser([FromBody] UserVM UserVM)
        {
            _db.Users.Delete(UserVM.Id);
            _db.Save();
            return Ok();
        }
    }
}

