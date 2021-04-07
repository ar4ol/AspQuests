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
            User user = _db.Users.GetAll().ToList().Find(x => x.Login == userModel.Login);
            return new ObjectResult(user);
        }

        [HttpPost]
        public async Task<ActionResult<User>> ChangeProfile([FromBody] UserModel userModel)
        {
            User user = _db.Users.GetAll().ToList().Find(x => x.Login == userModel.Login);
            user.Name = userModel.Name;
            user.Surname = userModel.Surname;
            user.Login = userModel.Login;
            user.Password = userModel.Password;
            _db.Users.Update(user);
            _db.Save();
            return Ok(user);
        }
    }
}
