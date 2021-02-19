namespace FleetManagement.Vehicles.Controllers
{
    public class VehicleModel
    {
        public string Model { get; set; }

        public string Make { get; set; }
        
        public int ProductionYear { get; set; }
        
        public string FriendlyName { get; set; }
    }

    public static class VehicleExtensions
    {
        public static VehicleModel ToModel(this Vehicle source)
        {
            return new VehicleModel() {FriendlyName = source.Name};
        }
    }
}