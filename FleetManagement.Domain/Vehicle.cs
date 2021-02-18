using System;
using CreoCraft.Domain;

namespace FleetManagement.Vehicles
{
    public class Vehicle : IEntity<Guid>
    {
        private Owner _owner;

        public Vehicle(Guid id, string name, long mileage)
        {
            Name = name;
            Mileage = mileage;
            Id = id;
        }

        public Guid Id { get; }

        public long Mileage { get; }

        public string Name { get; }

        public Owner Owner => _owner;

        public void ChangeOwner(Owner newOwner)
        {
            _owner = newOwner;
        }
    }
}