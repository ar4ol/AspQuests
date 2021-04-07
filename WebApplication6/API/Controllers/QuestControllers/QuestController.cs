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
    public class QuestController
    {
        private IUnitOfWork _db;

        public QuestController(IUnitOfWork unitOfWork)
        {
            _db = unitOfWork;
        }

        [Route("create")]
        [HttpPost]
        public async Task<ActionResult<Quest>> Create([FromBody] QuestModel questModel)
        {
            Quest quest = new Quest();
            quest.Name = questModel.Name;
            quest.User = questModel.User;
            quest.Route = questModel.Route;
            _db.Quests.Create(quest);
            quest = _db.Quests.GetAll().Last();
            return quest;
        }

        [Route("change")]
        [HttpPost]
        public async Task<ActionResult<Quest>> Change([FromBody] QuestModel questModel)
        {
            Quest quest = _db.Quests.Get(questModel.Id);
            quest.Route = questModel.Route;
            _db.Quests.Update(quest);
            return quest;
        }
    }
}
