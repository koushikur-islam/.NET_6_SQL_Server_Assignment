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
        private readonly IOptions<ConnectionStrings> _connectionStrings;
        public TaskManagementSystemDbContext(IOptions<ConnectionStrings> connectionStrings) : base()
        {
            _connectionStrings = connectionStrings;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionStrings.Value.ConnectionString);
            }
        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<RequestLog> RequestLogs { get; set; }
        public DbSet<ExceptionLog> ExceptionLogs { get; set; }
    }
}