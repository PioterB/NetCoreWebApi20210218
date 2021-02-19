using System;
using System.Collections.Generic;
using System.Linq;
using CreoCraft.Domain;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FleetManagement.Vehicles.Controllers
{
    [Route("api/v1/vehicles")]
    [ApiController]
    [Authorize]
    public class VehiclesController : ControllerBase
    {
        private readonly IRepository<Guid, Vehicle> _vehiclesRepository;
        private readonly IVehiclesService _vehiclesService;

        public VehiclesController(IVehiclesRepository vehiclesRepository, IVehiclesService vehiclesService)
        {
            _vehiclesRepository = vehiclesRepository;
            _vehiclesService = vehiclesService;
        }


        [HttpGet]
        [AllowAnonymous]
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
        [Authorize(Roles = "PowerUser")]
        public ActionResult<object> Create([FromBody] VehicleCreate value)
        {
            var vehicle = _vehiclesService.Create(value.Name, value.Mileage);
            _vehiclesRepository.Add(vehicle);
            return CreatedAtAction(nameof(Get), new { id = vehicle.Id }, vehicle.ToModel());
        }

        [HttpDelete("{name}")]
        public IActionResult Delete(Guid id)
        {
            _vehiclesRepository.Remove(id);

            return Ok();
        }

        [HttpPut("{name}")]
        [Authorize(Policy = "Admin")]
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
