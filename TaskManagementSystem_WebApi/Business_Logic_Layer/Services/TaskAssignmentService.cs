using AutoMapper;
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
    public class TaskAssignmentService : ITaskAssignmentService
    {
        private readonly IMapper _mapper;
        private readonly TaskAssignmentLogRepository _taskAssignmentLogRepository;

        //Registering necessary services with dependency injection
        public TaskAssignmentService(IMapper mapper, IConfiguration configuration)
        {
            _mapper = mapper;
            _taskAssignmentLogRepository = new TaskAssignmentLogRepository(configuration);
        }


        //Returns all the assignment objects from the task assignment log table.
        public async Task<IEnumerable<TaskAssignmentLogDto>> GetAllAsync()
        {
            string query = "SELECT * FROM TaskAssignmentsLogs;";
            return _mapper.Map<IEnumerable<TaskAssignmentLogDto>>(await _taskAssignmentLogRepository.GetAllAsync(query));
        }

        //Takes ID of a task and returns a signle assignment log record of that task.
        public async Task<TaskAssignmentLogDto> GetByTaskId(int id)
        {
            string query = $"SELECT * FROM TaskAssignmentsLogs WHERE TaskId={id};";
            return _mapper.Map<TaskAssignmentLogDto>(await _taskAssignmentLogRepository.GetAsync(query));
        }

        //Inserts a record to the task assignment table when inserting a new task.
        public async Task<bool> InsertAsync(TaskAssignmentLogDto taskAssignmentDto)
        {
            return await _taskAssignmentLogRepository.InsertAsync(_mapper.Map<TaskAssignmentsLogs>(taskAssignmentDto));  
        }

        //Updates a record to the task assignment table when necessary.
        //Mainly used for setting status to "Complete" or "Pending" for any task.
        public async Task<bool> UpdateAsync(TaskAssignmentLogDto taskAssignmentDto)
        {
            return await _taskAssignmentLogRepository.UpdateAsync(_mapper.Map<TaskAssignmentsLogs>(taskAssignmentDto));
        }

        //Takes a task assignment object as parameter and deletes it.
        //Returns boolean acknowledgement.
        public async Task<bool> DeleteAsync(TaskAssignmentLogDto taskAssignmentLogDto)
        {
            return await _taskAssignmentLogRepository.DeleteAsync(_mapper.Map<TaskAssignmentsLogs>(taskAssignmentLogDto));
        }
    }
}