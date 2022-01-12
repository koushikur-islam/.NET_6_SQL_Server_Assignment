using Business_Entity_Layer.DTO;
using Business_Logic_Layer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TaskManagementSystem_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }
        //Get all the tasks in the systen
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string? keyword)
        {
            IEnumerable<TaskDto> tasks;

            if (keyword!=null)
            {
                tasks = await _taskService.GetAsync(keyword);
                if (tasks.Count() >0 )
                {
                    return Ok(tasks);
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                tasks = await _taskService.GetAsync();
                if (tasks.Count() > 0)
                {
                    return Ok(tasks);
                }
                return NoContent();
            }
        }

        //Get Specific Task
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var task = await _taskService.GetAsync(id);
            if (task != null)
            {
                return Ok(task);
            }
            return NotFound();
        }

        //Insert a new task
        [HttpPost]
        public async Task<IActionResult> Insert(TaskDto taskDto)
        {
            var res = await _taskService.InsertAsync(taskDto);
            if (res)
            {
                var task = _taskService.GetAsync().Result.LastOrDefault();
                if (task != null)
                {
                    return Created("api/[controller]/" + task.Id, task);
                }
                return BadRequest();
            }
            return BadRequest("Failed to insert new task!");
        }

        //Update a new task
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TaskDto taskDto)
        {
            if (ModelState.IsValid)
            {
                var task = await _taskService.GetAsync(id);
                if (task != null)
                {
                    var res = await _taskService.UpdateAsync(id, taskDto);
                    if (res)
                    {
                        task.Title = taskDto.Title;
                        task.Description = taskDto.Description;
                        return Ok(task);
                    }
                    return BadRequest("Failed to update task!");
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return BadRequest("Invalid Model!");
            }
        }

        //Delete a task by id
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var taskDto = await _taskService.GetAsync(id);
            if (taskDto != null)
            {
                var res = await _taskService.DeleteAsync(taskDto);
                if (res)
                {
                    return NoContent();
                }
                return BadRequest("Failed to delete task!");
            }
            return NotFound();
        }
    }
}