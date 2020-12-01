using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication6.API.Model;
using WebApplication6.DAL.Entities;
using WebApplication6.DAL.Interfaces;
namespace WebApplication6.API.Controllers
{
        [Route("api/[controller]")]
        public class AllController : ControllerBase
        {            
            [HttpGet]
            public async Task<ActionResult<string>> GiveResult()
            {
                return Ok("Public Content.");
            }
        }
}

