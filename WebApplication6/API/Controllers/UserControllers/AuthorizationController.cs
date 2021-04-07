using Microsoft.AspNetCore.Mvc;
using WebApplication6.EF;
using WebApplication6.BLL.Services;
using WebApplication6.API.ViewModels;
using WebApplication6.DAL.Interfaces;
using System.Threading.Tasks;
using WebApplication6.DAL.Entities;
using System.Linq;
using System.Text.Json;

namespace WebApplication6.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorizationController : ControllerBase
    {
        private IUnitOfWork _db;

        public AuthorizationController(IUnitOfWork unitOfWork)
        {
            _db = unitOfWork;
        }

        [HttpPost]
        public async Task<ActionResult<string>> Authorization(UserVM UserVM)
        {
            AuthorizationService authService = new AuthorizationService(_db);
            bool identity = authService.GetIdentity(UserVM.Login, UserVM.Password);
            
            if (!identity)
            {
                return "Invalid username or password.";
            }

            User user = _db.Users.GetAll().ToList().Find(x => x.Login == UserVM.Login && x.Password == UserVM.Password);
            

            var response = new {
                user = user
            };

            return JsonSerializer.Serialize(response);
        }
    }
}
