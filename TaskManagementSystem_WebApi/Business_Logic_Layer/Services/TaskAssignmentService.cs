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
        public TaskAssignmentService(IMapper mapper, IConfiguration configuration)
        {
            _mapper = mapper;
            _taskAssignmentLogRepository = new TaskAssignmentLogRepository(configuration);
        }

        public async Task<bool> DeleteAsync(TaskAssignmentLogDto taskAssignmentLogDto)
        {
            return await _taskAssignmentLogRepository.DeleteAsync(_mapper.Map<TaskAssignmentsLogs>(taskAssignmentLogDto));
        }

        public async Task<IEnumerable<TaskAssignmentLogDto>> GetAllAsync()
        {
            string query = "SELECT * FROM TaskAssignmentsLogs;";
            return _mapper.Map<IEnumerable<TaskAssignmentLogDto>>(await _taskAssignmentLogRepository.GetAllAsync(query));
        }

        public async Task<TaskAssignmentLogDto> GetByTaskId(int id)
        {
            string query = $"SELECT * FROM TaskAssignmentsLogs WHERE TaskId={id};";
            return _mapper.Map<TaskAssignmentLogDto>(await _taskAssignmentLogRepository.GetAsync(query));
        }

        public async Task<bool> InsertAsync(TaskAssignmentLogDto taskAssignmentDto)
        {
            return await _taskAssignmentLogRepository.InsertAsync(_mapper.Map<TaskAssignmentsLogs>(taskAssignmentDto));  
        }

        public Task UpdateAsync(int id, TaskAssignmentLogDto taskAssignmentDto)
        {
            throw new NotImplementedException();
        }
    }
}