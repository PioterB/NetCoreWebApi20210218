using System;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using CreoCraft.Domain;
using CreoCraft.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace FleetManagement.Vehicles
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var tokenKey = Configuration["Jwt:key"];

            var SecretKey = Encoding.ASCII.GetBytes(tokenKey);

            services.AddControllers();
            services.AddVehicles();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, token =>
            {
                token.RequireHttpsMetadata = false;
                token.SaveToken = true;
                token.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    // Same Secret key will be used while creating the token
                    IssuerSigningKey = new SymmetricSecurityKey(SecretKey),
                    ValidateIssuer = true,
                    ValidIssuer = "http://localhost:45092/",
                    ValidateAudience = true,
                    ValidAudience = "http://localhost:5000/",
                    RequireExpirationTime = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromMinutes(1)
                };
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin", cfg =>
                {
                    cfg.AuthenticationSchemes.Add(JwtBearerDefaults.AuthenticationScheme);
                    cfg.RequireAuthenticatedUser();
                    cfg.RequireRole("PowerUser");
                    cfg.Requirements.Add(new MinimumSeniorityLevel(5));
                });
            });

            services.AddSingleton<IAuthorizationHandler, SeniorityLevelHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseTimestampMiddleware();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

    public class MinimumSeniorityLevel : IAuthorizationRequirement
    {
        public MinimumSeniorityLevel(int minimumLevel)
        {
            MinimumLevel = minimumLevel;
        }

        public int MinimumLevel { get; }
    }


    public class SeniorityLevelHandler : AuthorizationHandler<MinimumSeniorityLevel>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinimumSeniorityLevel requirement)
        {
            var user = context.User;
            var hasHired = user.HasClaim(claim => claim.Type == "Hired");
            if (hasHired == false)
            {
                return Task.CompletedTask;
            }

            var claim = user.Claims.FirstOrDefault(c => c.Type == "Hired");
            if (DateTime.TryParse(claim.Value, out DateTime hired) == false)
            {
                return Task.CompletedTask;
            }

            if (DateTime.Now.Year - hired.Year > requirement.MinimumLevel)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
