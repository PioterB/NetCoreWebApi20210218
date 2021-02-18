using System;
using CreoCraft.Domain;

namespace FleetManagement.Security
{
    public class ApplicationUser : IEntity<string>
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        public DateTime Hired { get; set; }

        public string Id { get; set; }

        public string Password { get; set; }
    }
}