using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication6.API.Model;
using WebApplication6.DAL.Entities;

namespace WebApplication6.BLL.BusinessModel
{
    public class TripService
    {
        public static void TripCreated(ref Trip trip)
        {
            if (trip.Created != true)
            {
                trip.MoveStart = DateTime.Now;
                trip.Created = true;
            }
        }

        public static void TripFill(ref Trip trip, double distance, double speed)
        {
            trip.Distance += distance;
            trip.MaxSpeed = speed > trip.MaxSpeed ? Convert.ToInt32(speed) : trip.MaxSpeed;
            trip.MinSpeed = speed < trip.MinSpeed ? Convert.ToInt32(speed) : trip.MinSpeed;
            trip.MoveEnd = DateTime.Now;
            trip.Speed = speed;
        }

        public static bool TransportInUsing(Transport transport)
        {
            return transport.TripId != -1;
        }        
    }
}
