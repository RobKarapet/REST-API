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
        //[HttpGet]
        //public object Get()
        //{
        //    return PersistenceLayer.TripsCRUD.GetTrips();
        //}

        [HttpGet]
        public object Get()
        {
            List<PersistenceLayer.Program.Trip> trips =
                PersistenceLayer.TripsCRUD.GetTrips();
            List<Trip2> trips2 = new List<Trip2>();

            foreach (var item in trips)
            {
                trips2.Add(new Trip2 {
                    EmployeeId = item.Employee.EmployeeId, 
                    FinalOdometer = item.FinalOdometer, 
                    FinishTime = item.FinishTime, 
                    InitialOdometer = item.InitialOdometer, 
                    ProjectFunction = item.ProjectFunction, 
                    ProjectTitle = item.ProjectTitle, 
                    Purpose = item.Purpose, 
                    StartTime = item.StartTime, 
                    TaskOrder = item.TaskOrder, 
                    TripId = item.TripId, 
                    TripPath = item.TripPath, 
                    VehicleId = item.Vehicle.VehicleId
                });
            }
            
            return trips2;
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
