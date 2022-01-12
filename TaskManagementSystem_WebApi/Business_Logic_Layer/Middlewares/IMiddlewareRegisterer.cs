﻿using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Middlewares
{
    public interface IMiddlewareRegisterer
    {
        IApplicationBuilder RegisterMiddlewares(IApplicationBuilder builder);
    }
}
