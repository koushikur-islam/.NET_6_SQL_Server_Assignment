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
        public async Task<IActionResult> Get()
        {
            var taskList = await _taskService.GetAsync();
            if (taskList.Count() > 0)
            {
                return Ok(taskList);
            }
            return NoContent();
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
                return Ok(_taskService.GetAsync().Result.LastOrDefault());
            }
            return BadRequest("Failed to insert new task!");
        }

        //Update a new task
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TaskDto taskDto)
        {
            if (ModelState.IsValid)
            {
                if (await _taskService.GetAsync(id) != null)
                {
                    var res = await _taskService.UpdateAsync(id, taskDto);
                    if (res)
                    {
                        return Ok(_taskService.GetAsync().Result.LastOrDefault());
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