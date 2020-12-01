using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication6.API.Model;
using WebApplication6.BLL.BusinessModel;
using WebApplication6.DAL.Entities;
using WebApplication6.DAL.Interfaces;

namespace WebApplication6.API.Controllers.TripControllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class TripController : ControllerBase
    {
        private IUnitOfWork _db;

        public TripController(IUnitOfWork unitOfWork)
        {
            _db = unitOfWork;
        }


        [Route("clienttripstart")]
        [HttpPost]
        public async Task<ActionResult<Trip>> TripStart([FromBody] TransportModel transportModel)
        {
            Trip trip = new Trip();
            trip.transportId = transportModel.id;
            _db.Trips.Create(trip);
            _db.Save();
            trip = _db.Trips.GetAll().Last();
            Transport transport = _db.Transports.Get(transportModel.id);
            transport.tripId = trip.id;
            _db.Transports.Update(transport);
            _db.Save();
            return trip;
        }


        [Route("clienttripend")]
        [HttpPost]
        public async Task<ActionResult<Transport>> TripEnd([FromBody] TransportModel transportModel)
        {            
            Transport transport = _db.Transports.Get(transportModel.id);
            transport.tripId = -1;
            _db.Transports.Update(transport);
            _db.Save();
            return Ok(transport);
        }


        [Route("iottripfill")]
        [HttpPost]
        public async Task<ActionResult<Trip>> FillTripInfo([FromBody] TripModel tripModel)
        {          

            Transport transport = _db.Transports.Get(tripModel.transportId);

            if(TripService.TransportInUsing(transport) == false) //если машина не находится в использовании, не создавать поездку и не заполнять про нее информацию
            {
                return Ok(null);
            }
            
            Trip trip = _db.Trips.Get(transport.tripId);

            TripService.TripCreated(ref trip, tripModel); // если поездка не начата, создаем поездку

            Point point = new Point();
            point.latitude = tripModel.latitude;
            point.longitude = tripModel.longitude;
            point.time = tripModel.time;
            _db.Points.Create(point);
            _db.Save();

            trip.passedRoute.Add(_db.Points.GetAll().Where(x => x.time == point.time).FirstOrDefault());
            trip.distance += tripModel.distance;
            trip.maxSpeed = tripModel.maxSpeed;
            trip.minSpeed = tripModel.minSpeed;
            trip.moveEnd = tripModel.moveEnd;
            trip.speed = tripModel.speed;

            _db.Trips.Update(trip);
            _db.Save();
            return Ok(trip);
        }


        [Route("clienttripinfo")]
        [HttpGet]
        public async Task<ActionResult<Trip>> GetTripInfo([FromBody] TransportModel transportModel)
        {
            Transport transport = _db.Transports.Get(transportModel.id); 

            if(TripService.TransportInUsing(transport) == false) //если машина не находится в использовании, не выводить информацию про ее поездку
            {
                return Ok(null);
            }

            Trip trip = _db.Trips.Get(transport.tripId);
            return trip;
        }

    }
}
