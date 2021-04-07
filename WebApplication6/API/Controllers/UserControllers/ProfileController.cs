using Microsoft.AspNetCore.Mvc;
using WebApplication6.EF;
using WebApplication6.API.ViewModels;
using WebApplication6.BLL.Services;
using WebApplication6.DAL.Entities;

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
        public async Task<ActionResult<User>> ShowProfile(UserVM UserVM)
        {
            User user = _db.Users.GetAll().ToList().Find(x => x.Login == UserVM.Login);
            return new ObjectResult(user);
        }

        [HttpPost]
        public async Task<ActionResult<User>> ChangeProfile([FromBody] UserVM UserVM)
        {
            User user = _db.Users.GetAll().ToList().Find(x => x.Login == UserVM.Login);
            user.Name = UserVM.Name;
            user.Surname = UserVM.Surname;
            user.Login = UserVM.Login;
            user.Password = UserVM.Password;
            _db.Users.Update(user);
            _db.Save();
            return Ok(user);
        }
    }
}
