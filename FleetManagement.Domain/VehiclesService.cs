using System;
using CreoCraft.Domain;

namespace FleetManagement.Vehicles
{
    public class VehiclesService : IVehiclesService
    {
        private readonly IIdGenerator<Guid> _idGenerator;

        public VehiclesService(IIdGenerator<Guid> idGenerator)
        {
            _idGenerator = idGenerator;
        }

        public Vehicle Create(string name, long mileage, Owner owner = null)
        {
            var item = new Vehicle(_idGenerator.Next(), name, mileage);
            if (owner != null)
            {
                item.ChangeOwner(owner);
            }

            return item;
        }
    }
}
