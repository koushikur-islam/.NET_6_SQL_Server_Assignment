using Business_Entity_Layer.DTO;
using Business_Logic_Layer.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Middlewares
{
    public class RequestArrivalMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IRequestLogService _requestLogService;
        public RequestArrivalMiddleware(RequestDelegate next, IRequestLogService requestLogService)
        {
            _next = next;
            _requestLogService = requestLogService;
        }

        public async Task Invoke(HttpContext context)
        {
            Console.WriteLine("Request Arrival : "+context.Request.Path.ToUriComponent() +"  -----> "+DateTime.Now);
            var newRequestLog = new RequestLogDto();
            newRequestLog.Route = context.Request.Path.ToUriComponent();
            newRequestLog.RequestedAt = DateTime.Now;
            _ = _requestLogService.InsertAsync(newRequestLog);
            await _next.Invoke(context);
        }
    }
}