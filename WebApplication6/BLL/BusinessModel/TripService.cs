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
        public static void TripCreated(ref Trip trip, TripModel tripModel)
        {
            if (trip.created != true)
            {
                trip.passedRoute = new List<Point>();
                trip.moveStart = tripModel.moveStart;
                trip.created = true;
            }
        }

        public static bool TransportInUsing(Transport transport)
        {
            return transport.tripId != -1;
        }
    }
}
