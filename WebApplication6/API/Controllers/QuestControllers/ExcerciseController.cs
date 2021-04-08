using Microsoft.AspNetCore.Mvc;
using WebApplication6.EF;
using WebApplication6.BLL.Services;
using WebApplication6.API.ViewModels;
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
            excercise.isCompleted = excerciseModel.isCompleted;
            excercise.Zone = excerciseModel.Zone;
            _db.Excercises.Create(excercise);
            excercise = _db.Excercises.GetAll().Last();
            return excercise;
        }

        [Route("change")]
        [HttpPatch]
        public async Task<ActionResult<Excercise>> Change([FromBody] ExcerciseVM excerciseModel)
        {
            Excercise excercise = _db.Excercises.Get(excerciseModel.Id);
            excercise.Name = excerciseModel.Name;
            excercise.isCompleted = excerciseModel.isCompleted;
            _db.Excercises.Update(excercise);
            return excercise;
        }


    }
}
