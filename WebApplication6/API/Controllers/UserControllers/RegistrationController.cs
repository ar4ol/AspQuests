using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication6.EF;
using WebApplication6.BLL.Services;
using WebApplication6.API.Model;
using WebApplication6.DAL.Entities;
using WebApplication6.DAL.Repositories;
using WebApplication6.DAL.Interfaces;
using System.Text.Json;

namespace WebApplication6.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegistrationController : ControllerBase
    {
        private IUnitOfWork _db;

        public RegistrationController(IUnitOfWork unitOfWork)
        {
            _db = unitOfWork;
        }

        [HttpPost]
        public async Task<ActionResult<string>> Registration([FromBody] UserModel userModel)
        {
            User user = new User();
            RegistrationService registrationService = new RegistrationService(_db);

            bool alredyreregister = registrationService.CheckAlreadyRegister(userModel.Login);
            if (!alredyreregister)
            {                
                user.Login = userModel.Login;
                user.Password = userModel.Password;
                user.Name = userModel.Name;
                user.Surname = userModel.Surname;
                user.Role = "user";
                _db.Users.Create(user);
                _db.Save();
            }
            
            AuthorizationService authService = new AuthorizationService(_db);
            var identity = authService.GetIdentity(user.Login, user.Password);
            object response;

            if (!alredyreregister)
            {
                response = new {
                    message = "Registration success!",
                    user = user,
                    access_token = TokenCreateService.CreateToken(identity).Result.Value
                };
            }
            else
            {
                response = new {
                    message = "Registration success!"
                };
            }

            return JsonSerializer.Serialize(response);

        }
    }
}
