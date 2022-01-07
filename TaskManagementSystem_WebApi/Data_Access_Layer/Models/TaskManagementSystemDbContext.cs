using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
namespace Data_Access_Layer.Models
{
    public class TaskManagementSystemDbContext:DbContext
    {
        private readonly IConfiguration _configuration;
        public TaskManagementSystemDbContext(IConfiguration configuration) : base()
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnectionString"));
            }
        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<RequestLog> RequestLogs { get; set; }
        public DbSet<ExceptionLog> ExceptionLogs { get; set; }
    }
}