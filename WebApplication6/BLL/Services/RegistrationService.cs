using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication6.BLL.Interfaces;
using WebApplication6.DAL.Entities;
using WebApplication6.DAL.Interfaces;
using WebApplication6.DAL.Repositories;
using WebApplication6.EF;

namespace WebApplication6.BLL.Services
{
    public class RegistrationService : IRegistrationService
    {
        private IUnitOfWork _db;

        public RegistrationService(IUnitOfWork unitOfWork)
        {
            _db = unitOfWork;
        }

        public bool CheckAlreadyRegister(string login)
        {
            User user = _db.Users.GetAll().ToList().Find(x => x.login == login);
            return user != null;
        }
    }
}
