using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExploreSolution.API.Middleware
{
    public class CustomHeaderMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomHeaderMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            bool isHeaderExist = context.Request.Headers.ContainsKey("H-Custom-Header");

            if (isHeaderExist)
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync("Request contains H-Custom-Header. Access Denied");
            }
            else
            {
                await _next.Invoke(context);
            }
        }
    }
}
