using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace Data_Access_Layer.Models
{
    public partial class TaskManagementSystemDBContext : DbContext
    {
        private readonly IConfiguration _configuration;
        //public TaskManagementSystemDBContext()
        //{

        //}
        public TaskManagementSystemDBContext(IConfiguration configuration):base()
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=TaskManagementSystemDB;Trusted_Connection=True;");
                Console.WriteLine(_configuration.GetConnectionString(_configuration.GetConnectionString("DefaultConnectionString")));
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnectionString"));
            }
        }

        public virtual DbSet<ExceptionLogs> ExceptionLogs { get; set; } = null!;
        public virtual DbSet<Persons> People { get; set; } = null!;
        public virtual DbSet<RequestLogs> RequestLogs { get; set; } = null!;
        public virtual DbSet<Tasks> Tasks { get; set; } = null!;
        public virtual DbSet<TaskAssignments> TaskAssignments { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExceptionLogs>(entity =>
            {
                entity.ToTable("ExceptionLog");

                entity.Property(e => e.ExceptionMessage).HasMaxLength(1000);

                entity.Property(e => e.LoggedAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<Persons>(entity =>
            {
                entity.ToTable("Person");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<RequestLogs>(entity =>
            {
                entity.ToTable("RequestLog");

                entity.Property(e => e.CompletedAt).HasColumnType("datetime");

                entity.Property(e => e.RequestedAt).HasColumnType("datetime");

                entity.Property(e => e.Route).HasMaxLength(150);
            });

            modelBuilder.Entity<Tasks>(entity =>
            {
                entity.ToTable("Task");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<TaskAssignments>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.HasOne(d => d.AssignedByNavigation)
                    .WithMany(p => p.TaskAssignmentAssignedByNavigations)
                    .HasForeignKey(d => d.AssignedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TaskAssignments_Person");

                entity.HasOne(d => d.AssignedToNavigation)
                    .WithMany(p => p.TaskAssignmentAssignedToNavigations)
                    .HasForeignKey(d => d.AssignedTo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TaskAssignments_Person1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
