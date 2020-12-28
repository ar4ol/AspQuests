using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication6.BLL.Interfaces;
using WebApplication6.DAL.Entities;

namespace WebApplication6.BLL.BusinessModel
{
    public class PointService 
    {
        public static void PointCreate(ref Point point, double latitude, double longitude, int tripId)
        {
            point.Latitude = latitude;
            point.Longitude = longitude;
            point.Time = DateTime.Now;
            point.TripId = tripId;
        }
    }
}
