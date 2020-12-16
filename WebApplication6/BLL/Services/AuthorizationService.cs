using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApplication6.BLL.Interfaces;
using WebApplication6.DAL.Entities;
using WebApplication6.DAL.Interfaces;
using WebApplication6.DAL.Repositories;
using WebApplication6.EF;

namespace WebApplication6.BLL.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        private IUnitOfWork _db;

        public AuthorizationService(IUnitOfWork unitOfWork)
        {
            _db = unitOfWork;
        }

        public ClaimsIdentity GetIdentity(string username, string password)
        {            
            User user = _db.Users.GetAll().ToList().Find(x => x.Login == username && x.Password == password);
            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login)
                };
                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }
            return null;
        }
    }
}
