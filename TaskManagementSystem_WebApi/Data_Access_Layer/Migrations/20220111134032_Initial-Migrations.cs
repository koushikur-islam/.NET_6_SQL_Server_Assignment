using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data_Access_Layer.Migrations
{
    public partial class InitialMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExceptionLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExceptionMessage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoggedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExceptionLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RequestLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Route = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ExceptionLogs",
                columns: new[] { "Id", "ExceptionMessage", "LoggedAt" },
                values: new object[,]
                {
                    { 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.,", new DateTime(2022, 1, 11, 19, 40, 31, 921, DateTimeKind.Local).AddTicks(7802) },
                    { 2, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.,", new DateTime(2022, 1, 11, 19, 40, 31, 921, DateTimeKind.Local).AddTicks(7803) },
                    { 3, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.,", new DateTime(2022, 1, 11, 19, 40, 31, 921, DateTimeKind.Local).AddTicks(7804) }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 1, 11, 19, 40, 31, 921, DateTimeKind.Local).AddTicks(7615), "Koushikur Islam Shohag", new DateTime(2022, 1, 11, 19, 40, 31, 921, DateTimeKind.Local).AddTicks(7625) },
                    { 2, new DateTime(2022, 1, 11, 19, 40, 31, 921, DateTimeKind.Local).AddTicks(7628), "Asef Hossain Khan", new DateTime(2022, 1, 11, 19, 40, 31, 921, DateTimeKind.Local).AddTicks(7629) },
                    { 3, new DateTime(2022, 1, 11, 19, 40, 31, 921, DateTimeKind.Local).AddTicks(7629), "Shameem Shahriar Shan", new DateTime(2022, 1, 11, 19, 40, 31, 921, DateTimeKind.Local).AddTicks(7630) }
                });

            migrationBuilder.InsertData(
                table: "RequestLogs",
                columns: new[] { "Id", "CompletedAt", "RequestedAt", "Route" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 1, 11, 19, 40, 31, 921, DateTimeKind.Local).AddTicks(7787), new DateTime(2022, 1, 11, 19, 40, 31, 921, DateTimeKind.Local).AddTicks(7787), "api/person/" },
                    { 2, new DateTime(2022, 1, 11, 19, 40, 31, 921, DateTimeKind.Local).AddTicks(7789), new DateTime(2022, 1, 11, 19, 40, 31, 921, DateTimeKind.Local).AddTicks(7788), "api/person/1" },
                    { 3, new DateTime(2022, 1, 11, 19, 40, 31, 921, DateTimeKind.Local).AddTicks(7790), new DateTime(2022, 1, 11, 19, 40, 31, 921, DateTimeKind.Local).AddTicks(7790), "api/task/" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "CreatedAt", "Description", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 1, 11, 19, 40, 31, 921, DateTimeKind.Local).AddTicks(7720), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", "Bring BreakFast", new DateTime(2022, 1, 11, 19, 40, 31, 921, DateTimeKind.Local).AddTicks(7720) },
                    { 2, new DateTime(2022, 1, 11, 19, 40, 31, 921, DateTimeKind.Local).AddTicks(7722), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", "Bring Lunch", new DateTime(2022, 1, 11, 19, 40, 31, 921, DateTimeKind.Local).AddTicks(7722) },
                    { 3, new DateTime(2022, 1, 11, 19, 40, 31, 921, DateTimeKind.Local).AddTicks(7723), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", "Bring Dinner", new DateTime(2022, 1, 11, 19, 40, 31, 921, DateTimeKind.Local).AddTicks(7724) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExceptionLogs");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "RequestLogs");

            migrationBuilder.DropTable(
                name: "Tasks");
        }
    }
}
