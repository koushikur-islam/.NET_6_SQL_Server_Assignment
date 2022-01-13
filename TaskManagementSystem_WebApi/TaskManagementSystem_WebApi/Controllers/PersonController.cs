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

        //From dependecy injection regestering necessary services.
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

        //Get a specific person in the system by ID
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

        //Get Assigned tasks for a person by his/her name in query string and an optional date query param
        //Peron's name is required in the query parameter to show all the assigned tasks to him.
        //Date in query param is optional. But if given with person's name then returns tasks assigned to him for that day.
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
            return NotFound();
        }

        //Get Requested tasks for a person by his/her name in query string and an optional date query param
        //Peron's name is required in the query parameter to show all the requested tasks by him.
        //Date in query param is optional. But if given with person's name then returns tasks requested by him for that day.
        [Route("api/[controller]/requested")]
        public async Task<IActionResult> GetRequestedTasksOfAPerson([FromQuery] string name, [FromQuery] string? date)
        {
            var person = (await _personService.GetAsync()).FirstOrDefault(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (person != null)
            {
                var tasks = await _taskService.GetRequestedTasksByPersonAsync(person.Id);
                if (date != null)
                {
                    tasks = tasks.Where(x => x.TaskDeadline.Date.ToString("yyyy-mm-dd").Equals(date, StringComparison.OrdinalIgnoreCase));
                }
                if (tasks.Count() > 0)
                {
                    return Ok(tasks);
                }
                return NoContent();
            }
            return NotFound();
        }


        //Get all the tasks completed by a specific person.
        //Persons name in the query parameter is required to show all the completed tasks by him.
        [Route("api/[controller]/completed")]
        public async Task<IActionResult> Get([FromQuery] string name)
        {
            if (name != null)
            {
                //Getting the person by his/her name and comparing the name ignoring case.
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

        //Update a person's details by ID
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

        //Delete a person by ID
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