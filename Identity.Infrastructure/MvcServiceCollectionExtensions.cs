using CreoCraft.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace FleetManagement.Security
{
    public static class MvcServiceCollectionExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<IRepository<string, ApplicationUser>, UsersRepository>();
        }
    }
}