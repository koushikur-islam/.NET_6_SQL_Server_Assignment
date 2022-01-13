﻿// <auto-generated />
using System;
using Data_Access_Layer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data_Access_Layer.Migrations
{
    [DbContext(typeof(TaskManagementSystemDBContext))]
    [Migration("20220113090329_Updated-Tasks-Models")]
    partial class UpdatedTasksModels
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Data_Access_Layer.Models.ExceptionLogs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ExceptionMessage")
                        .IsRequired()
                        .HasMaxLength(10000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LoggedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Route")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.HasKey("Id");

                    b.ToTable("ExceptionLogs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ExceptionMessage = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.,",
                            LoggedAt = new DateTime(2022, 1, 13, 15, 3, 29, 35, DateTimeKind.Local).AddTicks(3242),
                            Route = "api/person"
                        },
                        new
                        {
                            Id = 2,
                            ExceptionMessage = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.,",
                            LoggedAt = new DateTime(2022, 1, 13, 15, 3, 29, 35, DateTimeKind.Local).AddTicks(3244),
                            Route = "api/task/"
                        },
                        new
                        {
                            Id = 3,
                            ExceptionMessage = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.,",
                            LoggedAt = new DateTime(2022, 1, 13, 15, 3, 29, 35, DateTimeKind.Local).AddTicks(3244),
                            Route = "api/person"
                        });
                });

            modelBuilder.Entity("Data_Access_Layer.Models.Persons", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Persons");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2022, 1, 13, 15, 3, 29, 35, DateTimeKind.Local).AddTicks(3102),
                            Name = "Koushikur Islam Shohag",
                            UpdatedAt = new DateTime(2022, 1, 13, 15, 3, 29, 35, DateTimeKind.Local).AddTicks(3111)
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2022, 1, 13, 15, 3, 29, 35, DateTimeKind.Local).AddTicks(3115),
                            Name = "Asef Hossain Khan",
                            UpdatedAt = new DateTime(2022, 1, 13, 15, 3, 29, 35, DateTimeKind.Local).AddTicks(3115)
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2022, 1, 13, 15, 3, 29, 35, DateTimeKind.Local).AddTicks(3116),
                            Name = "Shameem Shahriar Shan",
                            UpdatedAt = new DateTime(2022, 1, 13, 15, 3, 29, 35, DateTimeKind.Local).AddTicks(3116)
                        });
                });

            modelBuilder.Entity("Data_Access_Layer.Models.RequestLogs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("CompletedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("RequestedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Route")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.HasKey("Id");

                    b.ToTable("RequestLogs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CompletedAt = new DateTime(2022, 1, 13, 15, 3, 29, 35, DateTimeKind.Local).AddTicks(3225),
                            RequestedAt = new DateTime(2022, 1, 13, 15, 3, 29, 35, DateTimeKind.Local).AddTicks(3223),
                            Route = "api/person/"
                        },
                        new
                        {
                            Id = 2,
                            CompletedAt = new DateTime(2022, 1, 13, 15, 3, 29, 35, DateTimeKind.Local).AddTicks(3227),
                            RequestedAt = new DateTime(2022, 1, 13, 15, 3, 29, 35, DateTimeKind.Local).AddTicks(3226),
                            Route = "api/person/1"
                        },
                        new
                        {
                            Id = 3,
                            CompletedAt = new DateTime(2022, 1, 13, 15, 3, 29, 35, DateTimeKind.Local).AddTicks(3228),
                            RequestedAt = new DateTime(2022, 1, 13, 15, 3, 29, 35, DateTimeKind.Local).AddTicks(3228),
                            Route = "api/task/"
                        });
                });

            modelBuilder.Entity("Data_Access_Layer.Models.TaskAssignmentsLogs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AssignedById")
                        .HasColumnType("int");

                    b.Property<int>("AssignedToId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CompletedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("TaskId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AssignedById");

                    b.HasIndex("AssignedToId");

                    b.HasIndex("TaskId")
                        .IsUnique();

                    b.ToTable("TaskAssignmentsLogs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AssignedById = 1,
                            AssignedToId = 2,
                            CompletedAt = new DateTime(2022, 1, 13, 15, 3, 29, 35, DateTimeKind.Local).AddTicks(3257),
                            CreatedAt = new DateTime(2022, 1, 13, 15, 3, 29, 35, DateTimeKind.Local).AddTicks(3256),
                            Status = "Pending",
                            TaskId = 1
                        },
                        new
                        {
                            Id = 2,
                            AssignedById = 3,
                            AssignedToId = 2,
                            CompletedAt = new DateTime(2022, 1, 13, 15, 3, 29, 35, DateTimeKind.Local).AddTicks(3259),
                            CreatedAt = new DateTime(2022, 1, 13, 15, 3, 29, 35, DateTimeKind.Local).AddTicks(3258),
                            Status = "Pending",
                            TaskId = 2
                        },
                        new
                        {
                            Id = 3,
                            AssignedById = 1,
                            AssignedToId = 3,
                            CompletedAt = new DateTime(2022, 1, 13, 15, 3, 29, 35, DateTimeKind.Local).AddTicks(3260),
                            CreatedAt = new DateTime(2022, 1, 13, 15, 3, 29, 35, DateTimeKind.Local).AddTicks(3260),
                            Status = "Completed",
                            TaskId = 3
                        });
                });

            modelBuilder.Entity("Data_Access_Layer.Models.Tasks", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<DateTime?>("TaskDeadline")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Tasks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2022, 1, 13, 15, 3, 29, 35, DateTimeKind.Local).AddTicks(3207),
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                            TaskDeadline = new DateTime(2022, 1, 13, 15, 3, 29, 35, DateTimeKind.Local).AddTicks(3208),
                            Title = "Bring BreakFast",
                            UpdatedAt = new DateTime(2022, 1, 13, 15, 3, 29, 35, DateTimeKind.Local).AddTicks(3207)
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2022, 1, 13, 15, 3, 29, 35, DateTimeKind.Local).AddTicks(3209),
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                            TaskDeadline = new DateTime(2022, 1, 13, 15, 3, 29, 35, DateTimeKind.Local).AddTicks(3210),
                            Title = "Bring Lunch",
                            UpdatedAt = new DateTime(2022, 1, 13, 15, 3, 29, 35, DateTimeKind.Local).AddTicks(3210)
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2022, 1, 13, 15, 3, 29, 35, DateTimeKind.Local).AddTicks(3211),
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                            TaskDeadline = new DateTime(2022, 1, 13, 15, 3, 29, 35, DateTimeKind.Local).AddTicks(3212),
                            Title = "Bring Dinner",
                            UpdatedAt = new DateTime(2022, 1, 13, 15, 3, 29, 35, DateTimeKind.Local).AddTicks(3211)
                        });
                });

            modelBuilder.Entity("Data_Access_Layer.Models.TaskAssignmentsLogs", b =>
                {
                    b.HasOne("Data_Access_Layer.Models.Persons", "AssignedByNavigation")
                        .WithMany("TaskAssignedByNavigations")
                        .HasForeignKey("AssignedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data_Access_Layer.Models.Persons", "AssignedToNavigation")
                        .WithMany("TaskAssignedToNavigations")
                        .HasForeignKey("AssignedToId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data_Access_Layer.Models.Tasks", "Tasks")
                        .WithOne("TaskAssignment")
                        .HasForeignKey("Data_Access_Layer.Models.TaskAssignmentsLogs", "TaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AssignedByNavigation");

                    b.Navigation("AssignedToNavigation");

                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("Data_Access_Layer.Models.Persons", b =>
                {
                    b.Navigation("TaskAssignedByNavigations");

                    b.Navigation("TaskAssignedToNavigations");
                });

            modelBuilder.Entity("Data_Access_Layer.Models.Tasks", b =>
                {
                    b.Navigation("TaskAssignment")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
