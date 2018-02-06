using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using static PersistenceLayer.Program;

namespace WebAPI.Controllers
{
    [Route("api/Employee")]
    public class EmployeeController : Controller
    {
        [HttpGet]
        public object Get()
        {
            List<PersistenceLayer.Program.Employee> o
                = PersistenceLayer.EmployeesCRUD.GetEmployees();

            return o;
        }

        [HttpGet("{id}")]
        public object Get(int id)
        {
            PersistenceLayer.Program.Employee o =
                PersistenceLayer.EmployeesCRUD.GetEmployee(id);

            return o;
        }

        [HttpGet("history/{id}")]
        public object Get(int id, int temp)
        {
            List<PersistenceLayer.Program.Trip> trips =
                PersistenceLayer.EmployeesCRUD.GetHistory(id);
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
            return PersistenceLayer.EmployeesCRUD.GetHistory(id);
        }

        [HttpPut]
        public void Put([FromBody]PersistenceLayer.Program.Employee value)
        {
            PersistenceLayer.EmployeesCRUD.AddEmployee(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            PersistenceLayer.EmployeesCRUD.DeleteEmployee(id);
        }
    }
}
