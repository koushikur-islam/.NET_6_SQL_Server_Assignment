using Business_Logic_Layer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace TaskManagementSystem_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;
        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _personService.GetAsync();
            if (result.Count > 0)
            {
                return Ok(await _personService.GetAsync());
            }
            else
            {
                return NoContent();
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _personService.GetAsync(id);
            if (result!=null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
