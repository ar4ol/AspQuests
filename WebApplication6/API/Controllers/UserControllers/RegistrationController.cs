using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication6.EF;
using WebApplication6.BLL.Services;
using WebApplication6.ViewModels;
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
        public async Task<ActionResult<string>> Registration([FromBody] UserVM UserVM)
        {
            User user = new User();
            RegistrationService registrationService = new RegistrationService(_db);

            bool alredyreregister = registrationService.CheckAlreadyRegister(UserVM.Login);
            if (!alredyreregister)
            {                
                user.Login = UserVM.Login;
                user.Password = UserVM.Password;
                user.Name = UserVM.Name;
                user.Surname = UserVM.Surname;
                user.Role = "user";
                _db.Users.Create(user);
                _db.Save();
            }
            
            object response;

            if (!alredyreregister)
            {
                response = new {
                    message = "Registration success!",
                    user = user
                };
            }
            else
            {
                response = new {
                    message = "User with the same login already register!"
                };
            }

            return JsonSerializer.Serialize(response);

        }
    }
}
