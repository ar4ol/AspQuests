using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication6.API.Model;
using WebApplication6.DAL.Entities;

namespace WebApplication6.BLL.Interfaces
{
    public interface ITripService
    {
        public void TripCreated(ref Trip trip, Point point, TripModel tripModel);
        public bool TransportInUsing(TransportModel transportModel);
    }
}
