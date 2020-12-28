using Microsoft.AspNetCore.Mvc;
using WebApplication6.EF;
using WebApplication6.BLL.Services;
using WebApplication6.API.Model;
using WebApplication6.DAL.Interfaces;
using System.Threading.Tasks;
using WebApplication6.DAL.Entities;
using System.Linq;
using System.Text.Json;
using System.Collections.Generic;

namespace WebApplication6.API.Controllers.RestControllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MarkController : ControllerBase
    {

        private IUnitOfWork _db;

        public MarkController(IUnitOfWork unitOfWork)
        {
            _db = unitOfWork;
        }

        [Route("create/{userid}_{restid}_{value}")]
        [HttpPost]
        public async Task<string> MakeMark([FromRoute] int userid, [FromRoute] int restid, [FromRoute] int value)
        {
            try
            {
                Mark mark = new Mark();
                mark.RestId = restid;
                mark.UserId = userid;
                mark.Value = value;
                _db.Marks.Create(mark);
                Rest rest = _db.Rests.GetAll().ToList().Find(x => x.Id == restid);
                rest.AvMark = ((rest.AvMark * rest.CountMarks) + value) / (rest.CountMarks + 1);
                rest.CountMarks = rest.CountMarks + 1;
                _db.Rests.Update(rest);
                _db.Save();
                return "Success!";
            }
            catch
            {
                return "Failed!";
            }

        }
    }
}
