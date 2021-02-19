using System;
using System.Collections.Generic;
using CreoCraft.Infrastructure;

namespace FleetManagement.Vehicles
{
    public class VehiclesRepository: InMemoryRepository<Guid, Vehicle>, IVehiclesRepository
    {
        public IEnumerable<Vehicle> FindBy(Owner owner)
        {
            throw new NotImplementedException();
        }
    }
}