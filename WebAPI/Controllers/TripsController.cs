using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// To Be Continued
namespace WebAPI.Controllers
{
    [Route("api/Trip")]
    public class TripsController : Controller
    {
        [HttpGet]
        public object Get()
        {
            return PersistenceLayer.TripsCRUD.GetTrips();
        }

        [HttpGet("{id}")]
        public object Get(int id)
        {
            return PersistenceLayer.TripsCRUD.GetTrip(id);
        }

        [HttpPost]
        public void Post([FromBody]PersistenceLayer.Program.Trip value)
        {
            PersistenceLayer.TripsCRUD.UpdateTrip(value);
        }

        [HttpPut("{VehicleId}/{EmployeeId}")]
        public void Put(int VehicleId, int EmployeeId,
            [FromBody]PersistenceLayer.Program.Trip value)
        {
            PersistenceLayer.TripsCRUD.
                AddTrip(value, VehicleId, EmployeeId);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            PersistenceLayer.TripsCRUD.DeleteTrip(id);
        }
    }
}
