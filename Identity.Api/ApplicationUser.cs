using System;
using CreoCraft.Domain;
using Microsoft.AspNetCore.Identity;

namespace FleetManagement.Security
{
    public class ApplicationUser: IdentityUser, IEntity<string>
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        public DateTime Hired { get; set; }
    }
}