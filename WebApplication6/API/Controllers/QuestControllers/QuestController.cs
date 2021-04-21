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
    public class QuestController
    {
        private IUnitOfWork _db;

        public QuestController(IUnitOfWork unitOfWork)
        {
            _db = unitOfWork;
        }

        [Route("getlistquests")]
        [HttpPost]
        public async Task<IEnumerable<Quest>> GetQuest([FromBody] UserVM userModel)
        {

            List<Quest> list = _db.Quests.GetAll().ToList().FindAll(x => x.UserId == userModel.Id);
            return list;
        }

        [Route("create")]
        [HttpPost]
        public async Task<ActionResult<Quest>> Create([FromBody] QuestVM questModel)
        {
            Quest quest = new Quest();
            quest.Name = questModel.Name;
            quest.UserId = questModel.UserId;
            quest.Route = questModel.Route;
            _db.Quests.Create(quest);
            _db.Save();
            return _db.Quests.GetAll().ToList().LastOrDefault();
        }

        [Route("change")]
        [HttpPatch]
        public async Task<ActionResult<Quest>> Change([FromBody] QuestVM questModel)
        {
            Quest quest = _db.Quests.Get(questModel.Id);
            quest.Name = questModel.Name;
            quest.Route = questModel.Route;
            _db.Quests.Update(quest);
            _db.Save();
            return quest; 
        }

        [Route("delete")]
        [HttpPost]
        public async Task<ActionResult<Quest>> Delete([FromBody] UserDeleteVM udModel)
        {
            Quest quest = _db.Quests.GetAll().ToList().Find(x => x.Id == udModel.QuestId);
            User user = _db.Users.Get(quest.UserId);
            if (user.Id == udModel.UserId)
            {
                _db.Quests.Delete(quest.Id);
                _db.Save();
                return quest;
            }
            else
            {
                return new Quest();
            }
        }
    }
}
