using Business_Entity_Layer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Services
{
    public interface ITaskAssignmentService
    {
        public Task<IEnumerable<TaskAssignmentLogDto>> GetAllAsync();
        public Task<TaskAssignmentLogDto> GetByTaskId(int id);
        public Task<bool> InsertAsync(TaskAssignmentLogDto taskAssignmentDto);
        public Task UpdateAsync(int id, TaskAssignmentLogDto taskAssignmentDto);
        public Task<bool> DeleteAsync(TaskAssignmentLogDto taskAssignmentLogDto);
    }
}