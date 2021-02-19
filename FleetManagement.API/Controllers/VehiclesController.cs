using System;
using System.Collections.Generic;
using System.Linq;
using CreoCraft.Domain;
using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FleetManagement.Vehicles.Controllers
{
    [Route("api/v1/vehicles")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IRepository<Guid, Vehicle> _vehiclesRepository;

        public VehiclesController(IVehiclesRepository vehiclesRepository)
        {
            _vehiclesRepository = vehiclesRepository;
        }


        [HttpGet]
        public IEnumerable<VehicleModel> Get()
        {
            return _vehiclesRepository.Get().Select(v => v.ToModel()).ToArray();
        }

        [HttpGet("{name}")]
        public ObjectResult Get(Guid id)
        {
            var vehicle = _vehiclesRepository.Get(id);

            if (vehicle == null)
            {
                return NotFound(new MissingItemModel("sdfsdfs"));
            }

            return Ok(vehicle.ToModel());
        }

        [HttpPost]
        public ActionResult<object> Create([FromBody] VehicleCreate value)
        {
            throw new NotImplementedException("use repo/domain");
            //var newVehicle = value.ToModel();

            //_vehiclesDatabase.Add(newVehicle);

            //return CreatedAtAction(nameof(Get), new { id = newVehicle.FriendlyName }, newVehicle);
        }

        [HttpDelete("{name}")]
        public IActionResult Delete(Guid id)
        {
            _vehiclesRepository.Remove(id);

            return Ok();
        }

        [HttpPut("{name}")]
        public ActionResult Update(string name, [FromBody] VehicleUpdate value)
        {
            throw new NotImplementedException("use repo/domain");

            //var vehicle =
            //    _vehiclesDatabase.FirstOrDefault(v => v.FriendlyName.Equals(name, StringComparison.OrdinalIgnoreCase));

            //if (vehicle == null)
            //{
            //    return NotFound();
            //}

            //vehicle.FriendlyName = value.Name;

            //return CreatedAtAction(nameof(Get), new { id = vehicle.FriendlyName }, null);
        }
    }
}
