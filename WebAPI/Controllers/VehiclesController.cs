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
