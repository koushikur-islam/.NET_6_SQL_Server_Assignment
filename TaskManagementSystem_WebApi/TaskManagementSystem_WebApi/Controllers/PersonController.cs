using Business_Entity_Layer.DTO;
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

        //Get all the person in the system
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _personService.GetAsync();
            if (result.Count() > 0)
            {
                return Ok(result);
            }
            else
            {
                return NoContent();
            }
        }

        //Get a specific person in the system by id
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _personService.GetAsync(id);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        //Create new person
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PersonDto personDto)
        {
            if (ModelState.IsValid)
            {
                var res = await _personService.InsertAsync(personDto);
                if (res)
                {
                    return Ok(_personService.GetAsync().Result.LastOrDefault());
                }
                else
                {
                    return BadRequest("Failed to create new person!");
                }
            }
            else
            {
                return BadRequest("Invalid Model!");
            }
        }

        //Update a person's details by id
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PersonDto personDto)
        {
            if (ModelState.IsValid)
            {
                if (await _personService.GetAsync(id) != null)
                {
                    var res = await _personService.UpdateAsync(id, personDto);
                    if (res)
                    {
                        return Ok();
                    }
                    return BadRequest("Failed to update person!");
                }
                else
                {
                    return NotFound("Person not found!");
                }
            }
            else
            {
                return BadRequest("Invalid model!");
            }
        }

        //Delete a person by id
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var personDto = await _personService.GetAsync(id);
            if (personDto != null)
            {
                var res = await _personService.DeleteAsync(personDto);
                if (res)
                {
                    return NoContent();
                }
                else
                {
                    return BadRequest("Failed to delete person!");
                }
            }
            else
            {
                return NotFound();
            }
        }
    }
}