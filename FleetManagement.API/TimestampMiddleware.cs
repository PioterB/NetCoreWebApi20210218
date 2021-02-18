using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FleetManagement.API
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class TimestampMiddleware
    {
        private readonly RequestDelegate _next;

        public TimestampMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {

            httpContext.Response.Headers.Add("X-ReceivedAt", DateTime.Now.ToString());

            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class TimestampMiddlewareExtensions
    {
        public static IApplicationBuilder UseTimestampMiddleware(this IApplicationBuilder builder)
        {
            /*
             * logic (judgment) 
             * middleware setup
             */

            return builder.UseMiddleware<TimestampMiddleware>();
        }
    }
}
