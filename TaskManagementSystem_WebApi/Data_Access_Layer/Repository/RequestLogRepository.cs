using Data_Access_Layer.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repository
{
    public class RequestLogRepository:Repository<RequestLogs>
    {
        public RequestLogRepository(IConfiguration configuration):base(configuration)   
        {

        }
    }
}
