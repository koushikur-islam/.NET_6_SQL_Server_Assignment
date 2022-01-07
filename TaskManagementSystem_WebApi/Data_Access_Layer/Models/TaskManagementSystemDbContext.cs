using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
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
        //private readonly IOptions<ConnectionStrings> _connectionStrings;
        //public TaskManagementSystemDbContext(IOptions<ConnectionStrings> connectionStrings) : base()
        //{
        //    _connectionStrings = connectionStrings;
        //}
        private readonly IConfiguration _configuration;
        public TaskManagementSystemDbContext(IConfiguration configuration) : base()
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("ConnectionString"));
            }
        }
        public DbSet<Persons> Persons { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<RequestLogs> RequestLogs { get; set; }
        public DbSet<ExceptionLogs> ExceptionLogs { get; set; }
    }
}