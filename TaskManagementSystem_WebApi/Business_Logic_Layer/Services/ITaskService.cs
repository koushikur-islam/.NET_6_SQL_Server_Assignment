using Business_Entity_Layer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Services
{
    public interface ITaskService
    {
        public Task<IEnumerable<TaskDto>> GetAsync();
        public Task<TaskDto> GetAsync(int id);
        public Task<IEnumerable<TaskDto>> GetAsync(string keyword);
        public Task<bool> InsertAsync(TaskDto taskDto);
        public Task<bool> UpdateAsync(int id, TaskDto taskDto);
        public Task<bool> DeleteAsync(TaskDto taskDto);

    }
}
