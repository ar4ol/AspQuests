﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication6.BLL.Interfaces
{
    interface IAuthorizationService
    {
        public bool GetIdentity(string login, string password);
    }
}
