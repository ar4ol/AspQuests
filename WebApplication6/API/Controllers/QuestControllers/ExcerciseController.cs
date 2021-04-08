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
    public class ExcerciseController : ControllerBase
    {
        private IUnitOfWork _db;

        public ExcerciseController(IUnitOfWork unitOfWork)
        {
            _db = unitOfWork;
        }

        [Route("create")]
        [HttpPost]
        public async Task<ActionResult<Excercise>> Create([FromBody] ExcerciseVM excerciseModel)
        {
            Excercise excercise = new Excercise();
            excercise.Name = excerciseModel.Name;
            excercise.ZoneId = excerciseModel.ZoneId;
            excercise.Description = excerciseModel.Description;
            _db.Excercises.Create(excercise);
            _db.Save();
            excercise = _db.Excercises.GetAll().Last();
            return excercise;
        }

        [Route("change")]
        [HttpPatch]
        public async Task<ActionResult<Excercise>> Change([FromBody] ExcerciseVM excerciseModel)
        {
            Excercise excercise = _db.Excercises.Get(excerciseModel.Id);
            excercise.Description = excerciseModel.Description;
            _db.Excercises.Update(excercise);
            return excercise;
        }

        [Route("delete")]
        [HttpDelete]
        public async Task<ActionResult<Excercise>> Delete([FromBody] UserDeleteVM ueModel)
        {
            Excercise excercise = _db.Excercises.Get(ueModel.ExerciseId);
            Zone zone = _db.Zones.Get(excercise.ZoneId);
            Quest quest = _db.Quests.Get(zone.QuestId);
            User user = _db.Users.Get(quest.UserId);
            if(user.Id == ueModel.UserId)
            {
                _db.Excercises.Delete(excercise.Id);
                return excercise;
            }
            else
            {
                return new Excercise();
            }
        }
    }
}
