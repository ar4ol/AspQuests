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
    public class OfferController : ControllerBase
    {
        
        private IUnitOfWork _db;

        public OfferController(IUnitOfWork unitOfWork)
        {
                _db = unitOfWork;
        }

        [Route("create/{userid}_{restid}_{date}")]
        [HttpPost]
        public async Task<string> MakeOffer([FromRoute] int userid, [FromRoute] int restid, [FromRoute] string date)
        {
            try
            {
                Offer offer = new Offer();
                offer.RestId = restid;
                offer.UserId = userid;
                offer.Date = date;
                _db.Offers.Create(offer);
                _db.Save();
                return "Success!";
            }
            catch
            {
                return "Failed!";
            }
        
        }

        [Route("all/{userid}")]
        [HttpGet]
        public async Task<ICollection<Offer>> Offers([FromRoute] int userid)
        {            
               return _db.Offers.GetAll().Where(x => x.UserId == userid).ToList();
        }
    }
}
