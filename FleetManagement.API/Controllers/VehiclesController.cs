using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;

namespace FleetManagement.API.Controllers
{
    [Route("api/v1/vehicles")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private static List<VehicleModel> _vehiclesDatabase = new List<VehicleModel>()
        {
            new VehicleModel(){FriendlyName = "Pinky", Make = "Volvo", Model = "V40", ProductionYear = 2004},
            new VehicleModel(){FriendlyName = "Yellow", Make = "Volvo", Model = "V60", ProductionYear = 2016},
            new VehicleModel(){FriendlyName = "Black", Make = "Volvo", Model = "V90", ProductionYear = 2019},
            new VehicleModel(){FriendlyName = "Monster", Make = "Volvo", Model = "XC90", ProductionYear = 2021},
        };


        [HttpGet]
        public IEnumerable<VehicleModel> Get()
        {
            return _vehiclesDatabase.ToArray();
        }

        [HttpGet("{name}")]
        public ObjectResult Get(string name)
        {
            var result = _vehiclesDatabase.FirstOrDefault(
                v => v.FriendlyName.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (result == null)
            {
                return NotFound(new MissingItemModel("sdfsdfs"));
            }

            return Ok(result);
        }

        [HttpPost]
        public ActionResult Create([FromBody] VehicleCreate value)
        {
            var newVehicle = value.ToModel();

            _vehiclesDatabase.Add(newVehicle);

            return CreatedAtAction(nameof(Get), new { id = newVehicle.FriendlyName }, newVehicle);
        }

        [HttpDelete("{name}")]
        public IActionResult Delete(string name)
        {
            var forRemoval =
                _vehiclesDatabase.FirstOrDefault(v => v.FriendlyName.Equals(name, StringComparison.OrdinalIgnoreCase));

            var removed = _vehiclesDatabase.Remove(forRemoval);

            return removed ? (IActionResult)Ok() : NoContent();
        }

        [HttpPut("{name}")]
        public ActionResult Update(string name, [FromBody] VehicleUpdate value)
        {
            var vehicle =
                _vehiclesDatabase.FirstOrDefault(v => v.FriendlyName.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (vehicle == null)
            {
                return NotFound();
            }

            vehicle.FriendlyName = value.Name;

            return CreatedAtAction(nameof(Get), new { id = vehicle.FriendlyName }, null);
        }
    }
}
