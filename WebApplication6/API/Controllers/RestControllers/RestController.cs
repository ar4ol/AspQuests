using Microsoft.AspNetCore.Mvc;
using WebApplication6.EF;
using WebApplication6.BLL.Services;
using WebApplication6.API.Model;
using WebApplication6.DAL.Interfaces;
using System.Threading.Tasks;
using WebApplication6.DAL.Entities;
using WebApplication6.API.ViewModels;
using System.Linq;
using System.Text.Json;
using System.Collections.Generic;

namespace WebApplication6.API.Controllers.RestControllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RestController : ControllerBase
    {
        private IUnitOfWork _db;

        public RestController(IUnitOfWork unitOfWork)
        {
            _db = unitOfWork;
        }

        [Route("all")]
        [HttpGet]
        public async Task<ICollection<Rest>> GetAll()
        {
            return _db.Rests.GetAll().ToList();
        }

        [Route("all/filter/{location}/{type}/{cost1}/{cost2}/{mark1}/{mark2}")]
        [HttpPost]
        public async Task<ICollection<Rest>> GetByFilter([FromRoute] string location, [FromRoute] string type, [FromRoute] string cost1, [FromRoute] string cost2, [FromRoute] string mark1, [FromRoute] string mark2)
        {
            List<Rest> rests = _db.Rests.GetAll().ToList();
            List<Rest> restsFilter = new List<Rest>();
            if (location != "null")
            {
                if (restsFilter.Count() == 0)
                {
                    restsFilter.AddRange(rests.FindAll(x => x.Location == location));
                }
                else
                {
                    restsFilter = restsFilter.FindAll(x => x.Location == location);
                }
                
            }
            if (type != "null")
            {
                if (restsFilter.Count() == 0)
                {
                    restsFilter.AddRange(rests.FindAll(x => x.Type == type));
                }
                else
                {
                    restsFilter = restsFilter.FindAll(x => x.Type == type);
                }
            }
            if(cost1 != "null")
            {
                if (restsFilter.Count() == 0)
                {
                    restsFilter.AddRange(rests.FindAll(x => x.Cost >= System.Int32.Parse(cost1) && x.Cost <= System.Int32.Parse(cost2)));
                }
                else
                {
                    restsFilter = restsFilter.FindAll(x => x.Cost >= System.Int32.Parse(cost1) && x.Cost <= System.Int32.Parse(cost2));
                }                
            }
            if(mark1 != "null")
            {
                if (restsFilter.Count() == 0)
                {
                    restsFilter.AddRange(rests.FindAll(x => x.AvMark >= System.Int32.Parse(mark1) && x.AvMark <= System.Int32.Parse(mark2)));
                }
                else
                {
                    restsFilter = restsFilter.FindAll(x => x.AvMark >= System.Int32.Parse(mark1) && x.AvMark <= System.Int32.Parse(mark2));
                }
            }
            return restsFilter;
        }

        [Route("info/{id}")]
        [HttpGet]
        public async Task<ActionResult<Rest>> GetInfo([FromRoute] int id)
        {
            return _db.Rests.GetAll().ToList().Find(x => x.Id == id);
        }

        [Route("make/{type}_{name}_{location}_{cost}")]
        [HttpPost]
        public async Task<ActionResult<string>> Create([FromRoute] string type, [FromRoute] string name, [FromRoute] string location, [FromRoute] int cost)
        {
            Rest rest = new Rest();
            rest.Type = type;
            rest.Name = name;
            rest.Location = location;
            rest.Cost = cost;
            _db.Rests.Create(rest);
            _db.Save();
            return "Success!";
        }
    }
}
