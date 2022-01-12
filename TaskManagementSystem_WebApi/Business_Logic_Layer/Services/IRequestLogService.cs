using Business_Entity_Layer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Services
{
    public interface IRequestLogService
    {
        public Task<RequestLogDto> GetAsync(string query);
        public Task<bool> InsertAsync(RequestLogDto requestLog);
        public Task<bool> UpdateAsync(RequestLogDto requestLog);
    }
}