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

namespace WebApplication6.API.Controllers.QuestControllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VisitorController : ControllerBase
    {
        private IUnitOfWork _db;

        public VisitorController(IUnitOfWork unitOfWork)
        {
            _db = unitOfWork;
        }

        [Route("create")]
        [HttpPost]
        public async Task<ActionResult<string>> Create([FromBody] VisitorVM visitorModel)
        {
            string login = _db.Visitors.GetAll().ToList().Find(x => x.Login == visitorModel.Login).Login;
            object response;
            Visitor visitor = new Visitor();
            visitor.Login = visitorModel.Login;
            visitor.Password = visitorModel.Password;
            visitor.Quest = visitorModel.Quest;
            visitor.Name = visitorModel.Name;
            visitor.Surname = visitorModel.Surname;
            if (login != null)
            {
                response = new {
                    message = "User with the same login already register!"
                };
            }
            else
            {
                response = new {
                    message = "Registration success!",
                    visitor = visitor
                };
            }

            return JsonSerializer.Serialize(response);
        }

        [Route("change")]
        [HttpPatch]
        public async Task<ActionResult<Visitor>> Change([FromBody] VisitorVM visitorModel)
        {
            Visitor visitor = _db.Visitors.GetAll().ToList().Find(x => x.Id == visitorModel.Id);
            visitor.Login = visitorModel.Login;
            visitor.Password = visitorModel.Password;
            visitor.Quest = visitorModel.Quest;
            visitor.Name = visitorModel.Name;
            visitor.Surname = visitorModel.Surname;
            _db.Visitors.Update(visitor);
            return visitor;
        }
    }
}
