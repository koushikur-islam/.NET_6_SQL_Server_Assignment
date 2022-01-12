using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Middlewares
{
    public static class MiddlewareRegisterer
    {
        public static IApplicationBuilder RegisterMiddlewares(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<RequestArrivalMiddleware>();
            builder.UseMiddleware<RequestExitMiddleware>();
            return builder;
        }
    }
}