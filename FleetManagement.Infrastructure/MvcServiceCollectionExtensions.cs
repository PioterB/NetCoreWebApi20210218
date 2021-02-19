 using System;
using CreoCraft.Domain;
using CreoCraft.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace FleetManagement.Vehicles
{
    public static class MvcServiceCollectionExtensions
    {
        public static void AddVehicles(this IServiceCollection services)
        {
            services.AddSingleton<IVehiclesRepository, VehiclesRepository>();
            services.AddSingleton<IIdGenerator<Guid>, LongIdGenerator>();
            services.AddScoped<IVehiclesService, VehiclesService>();
        }
    }
}