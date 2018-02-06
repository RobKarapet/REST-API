using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/Vehicle")]
    public class VehiclesController : Controller
    {
        [HttpGet]
        public object Get()
        {
            return PersistenceLayer.VehiclesCRUD.GetVehicles();
        }

        [HttpGet("{id}")]
        public object Get(int id)
        {
            return PersistenceLayer.VehiclesCRUD.GetVehicle(id);
        }

        [HttpGet("history/{id}")]
        public object Get(int id, int temp)
        {
            List<PersistenceLayer.Program.Trip> trips =
                PersistenceLayer.VehiclesCRUD.GetHistory(id);
            List<Trip2> trips2 = new List<Trip2>();

            foreach (var item in trips)
            {
                trips2.Add(new Trip2
                {
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

        [HttpPost("{id}")]
        public object Post(int id)
        {
            return PersistenceLayer.VehiclesCRUD.GetHistory(id);
        }

        [HttpPut]
        public void Put([FromBody]PersistenceLayer.
            Program.Vehicle value)
        {
            PersistenceLayer.VehiclesCRUD.AddVehicle(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            PersistenceLayer.VehiclesCRUD.DeleteVehicle(id);
        }
    }
}
