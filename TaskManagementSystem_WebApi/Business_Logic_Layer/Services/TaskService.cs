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
        public TaskService(IConfiguration configuration,IMapper mapper, ITaskAssignmentService taskAssignmentService)
        {
            _mapper = mapper;
            _taskRepository = new TaskRepository(configuration);
            _taskAssignmentService = taskAssignmentService;
        }
        public async Task<bool> DeleteAsync(TaskDto taskDto)
        {
            var res =  await _taskRepository.DeleteAsync(_mapper.Map<Tasks>(taskDto));
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

        public async Task<IEnumerable<TaskDto>> GetAsync()
        {
            string query = "SELECT * FROM Tasks;";
            return _mapper.Map<List<TaskDto>>(await _taskRepository.GetAllAsync(query));
        }

        public async Task<TaskDto> GetAsync(int id)
        {
            string query = $"SELECT * FROM Tasks WHERE id={id};";
            return _mapper.Map<TaskDto>(await _taskRepository.GetAsync(query));
        }

        public async Task<IEnumerable<TaskDto>> GetAsync(string keyword)
        {
            string query = $"SELECT * FROM Tasks WHERE description LIKE '%{keyword}%'";
            return _mapper.Map<IEnumerable<TaskDto>>(await _taskRepository.GetAllAsync(query));
        }

        public async Task<IEnumerable<TaskDto>> GetAssignedTasksByPersonAsync(int id)
        {
            string query = $"SELECT * FROM Tasks WHERE Id IN (SELECT Id FROM TaskAssignmentsLogs WHERE AssignedToId = {id});";
            return _mapper.Map<IEnumerable<TaskDto>>(await _taskRepository.GetAllAsync(query));
        }

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

        public async Task<bool> UpdateAsync(int id, TaskDto taskDto)
        {
            string query = $"SELECT * FROM Tasks WHERE id={id};";
            var task = await _taskRepository.GetAsync(query);
            if (task != null)
            {
                task.Title = taskDto.Title;
                task.Description = taskDto.Description;
                task.UpdatedAt = DateTime.Now;
                return await _taskRepository.UpdateAsync(task);
            }
            return false;
        }

        public async Task<IEnumerable<TaskDto>> GetCompletedTaskByPersonAsync(int id)
        {
            string query = $"SELECT * FROM Tasks WHERE Id IN (SELECT Id FROM TaskAssignmentsLogs WHERE AssignedToId = {id} AND Status='Completed');";
            return _mapper.Map<IEnumerable<TaskDto>>(await _taskRepository.GetAllAsync(query));
        }

        public async Task<IEnumerable<TaskDto>> GetRequestedTasksByPersonAsync(int id)
        {
            string query = $"SELECT * FROM Tasks WHERE Id IN (SELECT Id FROM TaskAssignmentsLogs WHERE AssignedById = {id});";
            return _mapper.Map<IEnumerable<TaskDto>>(await _taskRepository.GetAllAsync(query));
        }
    }
}