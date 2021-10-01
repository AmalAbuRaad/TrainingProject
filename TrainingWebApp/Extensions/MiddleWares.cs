using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingWebApp.MiddleWares;

namespace TrainingWebApp.Extensions
{
    public static class MiddleWares
    {
        public static IApplicationBuilder AddMiddleWares(
           this IApplicationBuilder app)
        {
            return app.UseMiddleware<CustomMiddleware>();
        }

        public static IApplicationBuilder UseJwtMiddleWare(
           this IApplicationBuilder app)
        {
            return app.UseMiddleware<JWTMiddleware>();
        }

    }
}
