﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebApplication6.BLL.Interfaces
{
    public interface IAuthorizationService
    {
        public ClaimsIdentity GetIdentity(string login, string password);
    }
}
