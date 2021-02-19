using System;
using System.Collections.Generic;
using CreoCraft.Domain;

namespace FleetManagement.Vehicles
{
    public interface IVehiclesRepository : IRepository<Guid, Vehicle>
    {
        IEnumerable<Vehicle> FindBy(Owner owner);
    }
}