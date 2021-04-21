using Microsoft.AspNetCore.Mvc;
using WebApplication6.EF;
using WebApplication6.BLL.Services;
using WebApplication6.ViewModels;
using WebApplication6.DAL.Interfaces;
using System.Threading.Tasks;
using WebApplication6.DAL.Entities;
using System.Linq;
using System.Text.Json;
using System.Collections.Generic;
using System;

namespace WebApplication6.API.Controllers.UserControllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AllController : ControllerBase
    {
        private IUnitOfWork _db;

        public AllController(IUnitOfWork unitOfWork)
        {
            _db = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<string>> GetAll()
        {
            string response = "Public Content!";

            return JsonSerializer.Serialize(response);
        }
    }
}
