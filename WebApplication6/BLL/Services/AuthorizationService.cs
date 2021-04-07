using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication6.EF;
using WebApplication6.BLL.Services;
using WebApplication6.DAL.Entities;
using WebApplication6.API.ViewModels;
using WebApplication6.DAL.Interfaces;
using WebApplication6.BLL.Interfaces;

namespace WebApplication6.BLL.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        public IUnitOfWork _db;

        public AuthorizationService(IUnitOfWork unitOfWork)
        {
            _db = unitOfWork;
        }

        public bool GetIdentity(string login, string password)
        {
            var user = _db.Users.GetAll().ToList().Find(x => x.Login == login && x.Password == password);
            return user != null;
        }
    }
}
