using System;
using CreoCraft.Domain;

namespace FleetManagement.Vehicles
{
    public interface IVehiclesRepository : IRepository<Guid, Vehicle>
    {
        
    }
}