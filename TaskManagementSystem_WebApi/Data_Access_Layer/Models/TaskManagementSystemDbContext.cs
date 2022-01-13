using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace Data_Access_Layer.Models
{
    //Inherits EF Core DbContext class for necessary context configurations.
    public partial class TaskManagementSystemDBContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public TaskManagementSystemDBContext(IConfiguration configuration):base()
        {
            _configuration = configuration;
        }

        public virtual DbSet<ExceptionLogs> ExceptionLogs { get; set; } = null!;
        public virtual DbSet<Persons> Persons { get; set; } = null!;
        public virtual DbSet<RequestLogs> RequestLogs { get; set; } = null!;
        public virtual DbSet<Tasks> Tasks { get; set; } = null!;
        public virtual DbSet<TaskAssignmentsLogs> TaskAssignmentsLogs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //From dependency injection gets the connection string from appsettings.json file.
                //In this case only one connection string is registered in the json file named DefaultConnectionString.
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnectionString"));
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //On creation of models seeding some data to the database

            modelBuilder.Entity<Persons>().HasData(
                new Persons
                {
                    Id = 1,
                    Name = "Koushikur Islam Shohag",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                },
                new Persons
                {
                    Id = 2,
                    Name = "Asef Hossain Khan",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                },
                new Persons
                {
                    Id = 3,
                    Name = "Shameem Shahriar Shan",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                }
            );

            modelBuilder.Entity<Tasks>().HasData(
               new Tasks
               {
                   Id = 1,
                   Title = "Bring BreakFast",
                   Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                   CreatedAt = DateTime.Now,
                   UpdatedAt = DateTime.Now,
                   TaskDeadline = DateTime.Now,
               },
               new Tasks
               {
                   Id = 2,
                   Title = "Bring Lunch",
                   Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                   CreatedAt = DateTime.Now,
                   UpdatedAt = DateTime.Now,
                   TaskDeadline = DateTime.Now,
               },
               new Tasks
               {
                   Id = 3,
                   Title = "Bring Dinner",
                   Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                   CreatedAt = DateTime.Now,
                   UpdatedAt = DateTime.Now,
                   TaskDeadline = DateTime.Now,
               }
           );

            modelBuilder.Entity<RequestLogs>().HasData(
                new RequestLogs
                {
                    Id = 1,
                    Route = "api/person/",
                    RequestedAt = DateTime.Now,
                    CompletedAt = DateTime.Now,
                },
                new RequestLogs
                {
                    Id = 2,
                    Route = "api/person/1",
                    RequestedAt = DateTime.Now,
                    CompletedAt = DateTime.Now,
                },
                    new RequestLogs
                {
                    Id = 3,
                    Route = "api/task/",
                    RequestedAt = DateTime.Now,
                    CompletedAt = DateTime.Now,
                }
            );
            modelBuilder.Entity<ExceptionLogs>().HasData(
                new ExceptionLogs
                {
                    Id =1,
                    Route = "api/person",
                    ExceptionMessage = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.,",
                    LoggedAt = DateTime.Now,
                },
                new ExceptionLogs
                {
                    Id=2,
                    Route = "api/task/",
                    ExceptionMessage = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.,",
                    LoggedAt = DateTime.Now,
                },
                new ExceptionLogs
                {
                    Id = 3,
                    Route = "api/person",
                    ExceptionMessage = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.,",
                    LoggedAt = DateTime.Now,
                }
            );
            modelBuilder.Entity<TaskAssignmentsLogs>().HasData(
                new TaskAssignmentsLogs
                {
                    Id = 1,
                    TaskId = 1,
                    AssignedById = 1,
                    AssignedToId = 2,
                    CreatedAt = DateTime.Now,
                    Status =  "Pending",
                    CompletedAt = DateTime.Now,
                },
                new TaskAssignmentsLogs
                {
                    Id = 2,
                    TaskId = 2,
                    AssignedById = 3,
                    AssignedToId = 2,
                    CreatedAt = DateTime.Now,
                    Status = "Pending",
                    CompletedAt = DateTime.Now,
                },
                new TaskAssignmentsLogs
                {
                    Id = 3,
                    TaskId = 3,
                    AssignedById = 1,
                    AssignedToId = 3,
                    CreatedAt = DateTime.Now,
                    Status = "Completed",
                    CompletedAt = DateTime.Now,
                }
            );
        }
    }
}