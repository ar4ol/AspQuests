﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication6.API.Model
{
    public class UserModel
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Role { get; set; }
    }
}
