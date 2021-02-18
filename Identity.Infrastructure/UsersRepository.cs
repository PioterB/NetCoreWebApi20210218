using System;
using CreoCraft.Domain;
using CreoCraft.Infrastructure;

namespace FleetManagement.Security
{
    internal class UsersRepository: InMemoryRepository<string, ApplicationUser>, IRepository<string, ApplicationUser>
    {
        public UsersRepository()
        {
            AddTestUsers();
        }

        private void AddTestUsers()
        {
            Add(new ApplicationUser()
            {
                Hired = new DateTime(2010, 10, 1), 
                Password = "x", 
                LastName = "Barankiewicz", 
                Name = "Piotr", 
                Id = "pb"
            });

            Add(new ApplicationUser()
            {
                Hired = new DateTime(2020, 10, 1),
                Password = "x",
                LastName = "Nowy",
                Name = "Janek",
                Id = "jn"
            });
        }
    }
}
