using Microsoft.Extensions.DependencyInjection;

namespace FleetManagement.Vehicles
{
    public static class MvcServiceCollectionExtensions
    {
        public static void AddDomain(this IServiceCollection services)
        {
            /*
             * missing forwarding (one type implements many interfaces), ie. Autofac has it
             */
            services.AddScoped<IVehiclesService, VehiclesService>();
        }
    }
}