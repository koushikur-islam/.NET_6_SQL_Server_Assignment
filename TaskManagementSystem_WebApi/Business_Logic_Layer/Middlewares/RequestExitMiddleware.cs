using Business_Entity_Layer.DTO;
using Business_Logic_Layer.Services;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Middlewares
{
    public class RequestExitMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IRequestLogService _requestLogService;

        //Registering necessary services with dependency injection.
        public RequestExitMiddleware(RequestDelegate next, IRequestLogService requestLogService)
        {
            _next = next;
            _requestLogService = requestLogService;
        }

        //First executing requested controller instructions and then before leaving the request updates the request log with completion date time.
        public async Task Invoke(HttpContext context)
        {
            await _next.Invoke(context);

            Console.WriteLine("Request Complete : " + context.Request.Path.ToUriComponent() + "  -----> " + DateTime.Now);
            string query = $"SELECT TOP 1 * FROM RequestLogs WHERE Route='{context.Request.Path.ToUriComponent()}' ORDER BY id DESC;";
            var req = await _requestLogService.GetAsync(query);
            req.CompletedAt = DateTime.Now;
            await _requestLogService.UpdateAsync(req);
        }
    }
}