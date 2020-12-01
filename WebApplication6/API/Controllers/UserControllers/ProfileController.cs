using Microsoft.AspNetCore.Mvc;
using WebApplication6.EF;
using WebApplication6.BLL.Services;
using WebApplication6.DAL.Entities;
using WebApplication6.API.Model;
using WebApplication6.DAL.Interfaces;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication6.API.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ProfileController : ControllerBase
    {
        private IUnitOfWork _db;

        public ProfileController(IUnitOfWork unitOfWork)
        {
            _db = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<User>> ShowProfile(UserModel userModel)
        {
            User user = _db.Users.GetAll().ToList().Find(x => x.login == userModel.login);
            return new ObjectResult(user);
        }

        [HttpPost]
        public async Task<ActionResult<User>> ChangeProfile(UserModel userModel)
        {
            User user = _db.Users.GetAll().ToList().Find(x => x.id == userModel.id);
            user.name = userModel.name;
            user.surname = userModel.surname;
            user.login = userModel.login;
            user.password = userModel.password;
            _db.Users.Update(user);
            _db.Save();
            return Ok(user);
        }
    }
}
