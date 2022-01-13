using Business_Logic_Layer.Services;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TaskManagementSystem_WebApi.Controllers
{
    [ApiExplorerSettings(IgnoreApi =true)]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        private readonly IExceptionLogService _exceptionLogService;
        public ErrorController(IExceptionLogService exceptionLogService)
        {
            _exceptionLogService = exceptionLogService;
        }

        [Route("/error")]
        public IActionResult HandleError()
        {
            //Logs any exception that occurs in the system to the database for any route with the exception message.
            //Returns the title and details of the exception as response of the request.

            var exceptionHandlerFeature = HttpContext.Features.Get<IExceptionHandlerFeature>()!;

            _exceptionLogService.InsertAsync(HttpContext.Request.Path.ToUriComponent(),exceptionHandlerFeature.Error.Message);

            return Problem(title: exceptionHandlerFeature.Error.Message, detail: exceptionHandlerFeature.Error.StackTrace);
        }
    }
}