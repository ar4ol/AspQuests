using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication6.BLL.Interfaces
{
    interface IRegistrationService
    {
        public bool CheckAlreadyRegister(string login);
    }
}
