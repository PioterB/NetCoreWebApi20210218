using System;
using CreoCraft.Infrastructure;

namespace FleetManagement.Vehicles
{
    public class VehiclesRepository: InMemoryRepository<Guid, Vehicle>, IVehiclesRepository
    {
    }
}