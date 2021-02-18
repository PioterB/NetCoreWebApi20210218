using System;
using CreoCraft.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace FleetManagement.Security
{
    public static class MvcServiceCollectionExtensions
    {
        public static void AddDomain(this IServiceCollection services)
        {
            /*
             * missing forwarding (one type implements many interfaces), ie. Autofac has it
             */
            services.AddScoped<AuthorizationService>();
            services.AddScoped<ITokenService>(x => x.GetRequiredService<AuthorizationService>());
            services.AddScoped<IAuthorizationService>(x => x.GetRequiredService<AuthorizationService>());
        }
    }
}