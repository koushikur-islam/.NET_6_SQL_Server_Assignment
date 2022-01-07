using Data_Access_Layer.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repository
{
    public class TaskRepository:Repository<Tasks>
    {
        public TaskRepository(IConfiguration configuration) :base(configuration)
        {

        }
    }
}