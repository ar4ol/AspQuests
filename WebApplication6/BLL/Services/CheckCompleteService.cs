using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication6.EF;
using WebApplication6.BLL.Services;
using WebApplication6.DAL.Entities;
using WebApplication6.ViewModels;
using WebApplication6.DAL.Interfaces;
using WebApplication6.BLL.Interfaces;

namespace WebApplication6.BLL.Services
{
    public class CheckCompleteService : ICheckCompletedService
    {
        public IUnitOfWork _db;

        public CheckCompleteService(IUnitOfWork unitOfWork)
        {
            _db = unitOfWork;
        }

        public Visitor CompleteTask(int visitorId)
        {
            Visitor visitor = _db.Visitors.Get(visitorId);
            Quest quest = _db.Quests.Get(visitor.QuestId);
            if(visitor.CompletedRoute == null)
            {
                visitor.CompletedRoute = "";
            }
            if(visitor.CompletedRoute.Length != quest.Route.Length)
            {
                visitor.CompletedRoute += quest.Route[visitor.CompletedRoute.Length];
            }
            return visitor;
        }
    }
}
