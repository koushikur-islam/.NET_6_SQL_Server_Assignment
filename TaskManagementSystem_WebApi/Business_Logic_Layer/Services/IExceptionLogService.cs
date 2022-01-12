using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Services
{
    public interface IExceptionLogService
    {
        public Task InsertAsync(string route, string message);
    }
}
