using System.ComponentModel.DataAnnotations;

namespace FleetManagement.API.Controllers
{
    public class VehicleUpdate
    {
        public string Name { get; set; }

        public string Make { get; set; }
    }
}