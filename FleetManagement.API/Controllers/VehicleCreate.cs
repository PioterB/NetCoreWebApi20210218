using System.ComponentModel.DataAnnotations;

namespace FleetManagement.API.Controllers
{
    public class VehicleCreate
    {
        [Required]
        [StringLength(int.MaxValue, MinimumLength = 1)]
        public string Name { get; set; }

        public string Model { get; set; }

        public string Make { get; set; }

        [Required]
        public long Mileage { get; set; }

        [ProductionYear(MinimumSupportedYear = 1995, AllowShortNotation = true)]
        public string ProductionYear { get; set; }
    }

    public static class VehicleCreateExtensions
    {
        public static VehicleModel ToModel(this VehicleCreate source)
        {
            return new VehicleModel()
            {
                FriendlyName = source.Name, 
                Make = source.Make, 
                Model = source.Model,
                ProductionYear = int.Parse(source.ProductionYear)
            };
        }
    }
}