using Business_Entity_Layer.CustomModels;
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
        //Keyword in the query parameter is optional but if given then returns all the tasks that matches the keyword in their description.
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

        //Get a specific Task by ID
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
        public async Task<IActionResult> Insert(TaskAssignmentModel taskAssignmentModel)
        {
            if (ModelState.IsValid)
            {
                var res = await _taskService.InsertAsync(taskAssignmentModel);
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
            return BadRequest("Invalid Model!");
        }

        //Update a task
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TaskUpdateModel taskUpdateModel)
        {
            if (ModelState.IsValid)
            {
                var task = await _taskService.GetAsync(id);
                if (task != null)
                {
                    var res = await _taskService.UpdateAsync(id, taskUpdateModel);
                    if (res)
                    {
                        task.Title = taskUpdateModel.Title;
                        task.Description = taskUpdateModel.Description;
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

        //Delete a task by ID
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