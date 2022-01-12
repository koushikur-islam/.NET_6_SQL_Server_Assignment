﻿// <auto-generated />
using System;
using Data_Access_Layer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data_Access_Layer.Migrations
{
    [DbContext(typeof(TaskManagementSystemDBContext))]
    partial class TaskManagementSystemDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LoggedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Route")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ExceptionLogs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ExceptionMessage = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.,",
                            LoggedAt = new DateTime(2022, 1, 12, 23, 36, 34, 885, DateTimeKind.Local).AddTicks(8675),
                            Route = "api/person"
                        },
                        new
                        {
                            Id = 2,
                            ExceptionMessage = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.,",
                            LoggedAt = new DateTime(2022, 1, 12, 23, 36, 34, 885, DateTimeKind.Local).AddTicks(8676),
                            Route = "api/task/"
                        },
                        new
                        {
                            Id = 3,
                            ExceptionMessage = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.,",
                            LoggedAt = new DateTime(2022, 1, 12, 23, 36, 34, 885, DateTimeKind.Local).AddTicks(8677),
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
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Persons");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2022, 1, 12, 23, 36, 34, 885, DateTimeKind.Local).AddTicks(8532),
                            Name = "Koushikur Islam Shohag",
                            UpdatedAt = new DateTime(2022, 1, 12, 23, 36, 34, 885, DateTimeKind.Local).AddTicks(8541)
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2022, 1, 12, 23, 36, 34, 885, DateTimeKind.Local).AddTicks(8544),
                            Name = "Asef Hossain Khan",
                            UpdatedAt = new DateTime(2022, 1, 12, 23, 36, 34, 885, DateTimeKind.Local).AddTicks(8545)
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2022, 1, 12, 23, 36, 34, 885, DateTimeKind.Local).AddTicks(8546),
                            Name = "Shameem Shahriar Shan",
                            UpdatedAt = new DateTime(2022, 1, 12, 23, 36, 34, 885, DateTimeKind.Local).AddTicks(8546)
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
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RequestLogs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CompletedAt = new DateTime(2022, 1, 12, 23, 36, 34, 885, DateTimeKind.Local).AddTicks(8657),
                            RequestedAt = new DateTime(2022, 1, 12, 23, 36, 34, 885, DateTimeKind.Local).AddTicks(8657),
                            Route = "api/person/"
                        },
                        new
                        {
                            Id = 2,
                            CompletedAt = new DateTime(2022, 1, 12, 23, 36, 34, 885, DateTimeKind.Local).AddTicks(8659),
                            RequestedAt = new DateTime(2022, 1, 12, 23, 36, 34, 885, DateTimeKind.Local).AddTicks(8658),
                            Route = "api/person/1"
                        },
                        new
                        {
                            Id = 3,
                            CompletedAt = new DateTime(2022, 1, 12, 23, 36, 34, 885, DateTimeKind.Local).AddTicks(8660),
                            RequestedAt = new DateTime(2022, 1, 12, 23, 36, 34, 885, DateTimeKind.Local).AddTicks(8660),
                            Route = "api/task/"
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
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Tasks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2022, 1, 12, 23, 36, 34, 885, DateTimeKind.Local).AddTicks(8641),
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                            Title = "Bring BreakFast",
                            UpdatedAt = new DateTime(2022, 1, 12, 23, 36, 34, 885, DateTimeKind.Local).AddTicks(8642)
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2022, 1, 12, 23, 36, 34, 885, DateTimeKind.Local).AddTicks(8643),
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                            Title = "Bring Lunch",
                            UpdatedAt = new DateTime(2022, 1, 12, 23, 36, 34, 885, DateTimeKind.Local).AddTicks(8644)
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2022, 1, 12, 23, 36, 34, 885, DateTimeKind.Local).AddTicks(8644),
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                            Title = "Bring Dinner",
                            UpdatedAt = new DateTime(2022, 1, 12, 23, 36, 34, 885, DateTimeKind.Local).AddTicks(8645)
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
