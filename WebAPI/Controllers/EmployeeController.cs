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
