using AutoMapper;
using Business_Entity_Layer.CustomModels;
using Business_Entity_Layer.DTO;
using Data_Access_Layer.Models;
using Data_Access_Layer.Repository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Services
{
    public class TaskService : ITaskService
    {
        private readonly IMapper _mapper;
        private readonly TaskRepository _taskRepository;
        private readonly ITaskAssignmentService _taskAssignmentService;

        //Registerring necessary services with dependency injection
        public TaskService(IConfiguration configuration,IMapper mapper, ITaskAssignmentService taskAssignmentService)
        {
            _mapper = mapper;
            _taskRepository = new TaskRepository(configuration);
            _taskAssignmentService = taskAssignmentService;
        }


        //Gets all the tasks from DB using Dapper from repository and returns the mapped dto collections using AutoMapper.
        public async Task<IEnumerable<TaskDto>> GetAsync()
        {
            string query = "SELECT * FROM Tasks;";
            return _mapper.Map<List<TaskDto>>(await _taskRepository.GetAllAsync(query));
        }

        //Gets a specific task by its ID using Dapper from repository and returns the mapped dto using AutoMapper
        public async Task<TaskDto> GetAsync(int id)
        {
            string query = $"SELECT * FROM Tasks WHERE id={id};";
            return _mapper.Map<TaskDto>(await _taskRepository.GetAsync(query));
        }

        //Gets all the tasks whose description matches with the given keyword using Dapper and returns the collection of mapped Dtos.
        public async Task<IEnumerable<TaskDto>> GetAsync(string keyword)
        {
            string query = $"SELECT * FROM Tasks WHERE description LIKE '%{keyword}%'";
            return _mapper.Map<IEnumerable<TaskDto>>(await _taskRepository.GetAllAsync(query));
        }

        //Gets all the tasks from DB using Dapper those are assigned to a specific person and returns it.
        public async Task<IEnumerable<TaskDto>> GetAssignedTasksByPersonAsync(int id)
        {
            string query = $"SELECT * FROM Tasks WHERE Id IN (SELECT Id FROM TaskAssignmentsLogs WHERE AssignedToId = {id});";
            return _mapper.Map<IEnumerable<TaskDto>>(await _taskRepository.GetAllAsync(query));
        }

        //Returns all the tasks that are completed by a specific person
        public async Task<IEnumerable<TaskDto>> GetCompletedTaskByPersonAsync(int id)
        {
            string query = $"SELECT * FROM Tasks WHERE Id IN (SELECT Id FROM TaskAssignmentsLogs WHERE AssignedToId = {id} AND Status='Completed');";
            return _mapper.Map<IEnumerable<TaskDto>>(await _taskRepository.GetAllAsync(query));
        }

        //Returns all the tasks that are requested by a specific person
        public async Task<IEnumerable<TaskDto>> GetRequestedTasksByPersonAsync(int id)
        {
            string query = $"SELECT * FROM Tasks WHERE Id IN (SELECT Id FROM TaskAssignmentsLogs WHERE AssignedById = {id});";
            return _mapper.Map<IEnumerable<TaskDto>>(await _taskRepository.GetAllAsync(query));
        }

        //Inserts a task and then logs the details to the task assignment log with the task id and assignedby and assigned to person data.
        //If fails to assign task assignment details then deletes the taks as well.
        //Finally sends appropriate acknowledgement.
        public async Task<bool> InsertAsync(TaskAssignmentModel taskAssignmentModel)
        {
            var taskDto = new TaskDto();
            taskDto.Title = taskAssignmentModel.Title;
            taskDto.Description = taskAssignmentModel.Description;
            taskDto.CreatedAt = DateTime.Now;
            taskDto.UpdatedAt = DateTime.Now;
            taskDto.TaskDeadline = taskAssignmentModel.TaskDeadline;
            var res =  await _taskRepository.InsertAsync(_mapper.Map<Tasks>(taskDto));
            if (res)
            {
                var assignedTask = (await GetAsync()).LastOrDefault();
                if (assignedTask!=null)
                {
                    TaskAssignmentLogDto taskLogDto = new TaskAssignmentLogDto();
                    taskLogDto.TaskId = assignedTask.Id;
                    taskLogDto.Status = "Pending";
                    taskLogDto.CreatedAt = DateTime.Now;
                    taskLogDto.AssignedById = taskAssignmentModel.AssignedById;
                    taskLogDto.AssignedToId = taskAssignmentModel.AssignedToId;
                    var result = await _taskAssignmentService.InsertAsync(taskLogDto);
                    if (result)
                    {
                        return true;
                    }
                    else
                    {
                        await DeleteAsync(assignedTask);
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        //Updates a task if it is found and sends right acknowledgement
        public async Task<bool> UpdateAsync(int id, TaskUpdateModel taskUpdateModel)
        {
            string query = $"SELECT * FROM Tasks WHERE id={id};";
            var task = await _taskRepository.GetAsync(query);
            if (task != null)
            {
                task.Title = taskUpdateModel.Title;
                task.Description = taskUpdateModel.Description;
                task.UpdatedAt = DateTime.Now;
                 
                //Change the status "Completed" or "Pending" in the task assignment log table
                var taskLog = await _taskAssignmentService.GetByTaskId(id);
                taskLog.Status = taskUpdateModel.Status;
                await _taskAssignmentService.UpdateAsync(taskLog);

                return await _taskRepository.UpdateAsync(task);
            }
            return false;
        }

        //Deletes any task if it is found with EF Core and returns appropirate acknowledgement of deletion
        public async Task<bool> DeleteAsync(TaskDto taskDto)
        {
            var res = await _taskRepository.DeleteAsync(_mapper.Map<Tasks>(taskDto));
            if (res)
            {
                var taskAssignmentLog = await _taskAssignmentService.GetByTaskId(taskDto.Id);
                if (taskAssignmentLog != null)
                {
                    await _taskAssignmentService.DeleteAsync(taskAssignmentLog);
                }
                return true;
            }
            return false;
        }

    }
}