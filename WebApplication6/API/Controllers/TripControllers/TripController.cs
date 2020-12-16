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
    [Route("api/[controller]")]
    public class TripController : ControllerBase
    {
        private IUnitOfWork _db;

        public TripController(IUnitOfWork unitOfWork)
        {
            _db = unitOfWork;
        }


        [Route("clienttripstart/{id}")]
        [HttpGet]
        public async Task<ActionResult<Trip>> TripStart(int id)
        {
            Trip trip = new Trip();
            trip.TransportId = id;
            _db.Trips.Create(trip);
            _db.Save();
            trip = _db.Trips.GetAll().Last();
            Transport transport = _db.Transports.Get(id);
            transport.TripId = trip.Id;
            _db.Transports.Update(transport);
            _db.Save();
            return trip;
        }


        [Route("clienttripend/{id}")]
        [HttpGet]
        public async Task<ActionResult<Transport>> TripEnd(int id)
        {            
            Transport transport = _db.Transports.Get(id);
            transport.TripId = -1;
            _db.Transports.Update(transport);
            _db.Save();
            return Ok(transport);
        }


        [Route("iottripfill/{tripId}:{latitude}:{longitude}:{distance}:{speed}")]
        [HttpGet]
        public async Task<string/*ActionResult<Trip>*/> FillTripInfo([FromRoute] int tripId, [FromRoute] double latitude, [FromRoute] double longitude, [FromRoute] double distance, [FromRoute] double speed)
        {
            Trip trip = _db.Trips.Get(tripId);
            Transport transport = _db.Transports.Get(trip.TransportId);

            if(TripService.TransportInUsing(transport) == false) //если машина не находится в использовании, не создавать поездку и не заполнять про нее информацию
            {
                return "Car not in using!";
            }

            TripService.TripCreated(ref trip); // если поездка не начата, создаем поездку    
            TripService.TripFill(ref trip, distance, speed);

            Point point = new Point();

            PointService.PointCreate(ref point, latitude, longitude, tripId);
            
            _db.Points.Create(point);
            _db.Save();

            

            _db.Trips.Update(trip);
            _db.Save();
            return "Ok";
        }


        [Route("clienttripinfo/{carId}")]
        [HttpGet]
        public async Task<string> СlientTripInfo(string carId)
        {
            Transport transport = _db.Transports.Get(Convert.ToInt32(carId)); 

            if(TripService.TransportInUsing(transport) == false) //если машина не находится в использовании, не выводить информацию про ее поездку
            {
                return "Car not in using!";
            }

            return Convert.ToString(transport.TripId);
        }

        [Route("gettripinfo")]
        [HttpPost]
        public async Task<ActionResult<string>> GetTripInfo([FromBody] Trip tripModel)
        {
            Trip trip = _db.Trips.Get(tripModel.Id);
                        
            return Ok(trip);
        }

        [Route("getlocation")]
        [HttpPost]
        public async Task<ActionResult<Point>> GetLocation([FromBody] Trip tripModel)
        {
            Trip trip = _db.Trips.Get(tripModel.Id);
            Point point = _db.Points.GetAll().ToList().FindLast(x => x.TripId == trip.Id);
            return Ok(point);
        }

    }
}
