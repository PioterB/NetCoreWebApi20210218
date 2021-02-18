namespace FleetManagement.Vehicles
{
    public interface IVehiclesService
    {
        Vehicle Create(string name, long mileage, Owner owner = null);
    }
}