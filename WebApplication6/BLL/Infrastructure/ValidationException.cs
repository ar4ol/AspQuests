﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication6.BLL.Infrastructure
{
    public class ValidationException : Exception
    {
        public string Property { get; protected set; }
        public ValidationException(string message, string prop) : base(message)
        {
            Property = prop;
        }
    }
}
