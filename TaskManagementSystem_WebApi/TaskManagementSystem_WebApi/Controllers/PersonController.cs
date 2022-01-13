using Business_Entity_Layer.DTO;
using Business_Logic_Layer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace TaskManagementSystem_WebApi.Controllers
{
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;
        private readonly ITaskService _taskService;
        public PersonController(IPersonService personService, ITaskService taskService)
        {
            _personService = personService;
            _taskService = taskService;
        }

        //Get all the person in the system
        [HttpGet]
        [Route("api/[controller]/")]
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
        [HttpGet]
        [Route("api/[controller]/{id}")]
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

        //Get Assigned tasks for a day
        [Route("api/[controller]/assigned")]
        public async Task<IActionResult> GetAssignedTasksOfAPerson([FromQuery] string name, [FromQuery] string? date)
        {
            var person = (await _personService.GetAsync()).FirstOrDefault(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (person!=null)
            {
                var tasks = await _taskService.GetAssignedTasksByPersonAsync(person.Id);
                if (date!=null)
                {
                    tasks = tasks.Where(x => x.TaskDeadline.ToString("yyyy-mm-dd").Equals(date, StringComparison.OrdinalIgnoreCase));
                }
                if (tasks.Count() > 0)
                {
                    return Ok(tasks);
                }
                return NoContent();
            }
            return BadRequest();
        }

        //Get Requested tasks for a day
        [Route("api/[controller]/requested")]
        public async Task<IActionResult> GetRequestedTasksOfAPerson([FromQuery] string name, [FromQuery] string? date)
        {
            var person = (await _personService.GetAsync()).FirstOrDefault(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (person != null)
            {
                var tasks = await _taskService.GetRequestedTasksByPersonAsync(person.Id);
                if (date != null)
                {
                    tasks = tasks.Where(x => x.TaskDeadline.ToString("yyyy-mm-dd").Equals(date, StringComparison.OrdinalIgnoreCase));
                }
                if (tasks.Count() > 0)
                {
                    return Ok(tasks);
                }
                return NoContent();
            }
            return BadRequest();
        }


        //Get completed tasks by person
        [Route("api/[controller]/completed")]
        public async Task<IActionResult> Get([FromQuery] string name)
        {
            if (name != null)
            {
                var person = (await _personService.GetAsync()).FirstOrDefault(x=>x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
                if (person!=null)
                {
                    var tasks = await _taskService.GetCompletedTaskByPersonAsync(person.Id);
                    if (tasks.Count() > 0)
                    {
                        return Ok(tasks);
                    }
                }
                return NoContent();
            }
            return BadRequest();
        }

        //Create new person
        [HttpPost]
        [Route("api/[controller]")]
        public async Task<IActionResult> Post([FromBody] PersonDto personDto)
        {
            if (ModelState.IsValid)
            {
                var res = await _personService.InsertAsync(personDto);
                if (res)
                {
                    var person = _personService.GetAsync().Result.LastOrDefault();
                    if (person == null)
                    {
                        return BadRequest("Failed to created new peron!");
                    }
                    return Created("api/[controller]/"+person.Id,person);
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
        [HttpPut]
        [Route("api/[controller]/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PersonDto personDto)
        {
            if (ModelState.IsValid)
            {
                var person = await _personService.GetAsync(id);
                if (person != null)
                {
                    var res = await _personService.UpdateAsync(id, personDto);
                    if (res)
                    {
                        person.Name = personDto.Name;
                        return Ok(person);
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
        [HttpDelete]
        [Route("api/[controller]/{id}")]
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