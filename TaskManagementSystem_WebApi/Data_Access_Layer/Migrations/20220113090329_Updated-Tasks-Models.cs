using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data_Access_Layer.Migrations
{
    public partial class UpdatedTasksModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "TaskDeadline",
                table: "Tasks",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "ExceptionLogs",
                keyColumn: "Id",
                keyValue: 1,
                column: "LoggedAt",
                value: new DateTime(2022, 1, 13, 15, 3, 29, 35, DateTimeKind.Local).AddTicks(3242));

            migrationBuilder.UpdateData(
                table: "ExceptionLogs",
                keyColumn: "Id",
                keyValue: 2,
                column: "LoggedAt",
                value: new DateTime(2022, 1, 13, 15, 3, 29, 35, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "ExceptionLogs",
                keyColumn: "Id",
                keyValue: 3,
                column: "LoggedAt",
                value: new DateTime(2022, 1, 13, 15, 3, 29, 35, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 13, 15, 3, 29, 35, DateTimeKind.Local).AddTicks(3102), new DateTime(2022, 1, 13, 15, 3, 29, 35, DateTimeKind.Local).AddTicks(3111) });

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 13, 15, 3, 29, 35, DateTimeKind.Local).AddTicks(3115), new DateTime(2022, 1, 13, 15, 3, 29, 35, DateTimeKind.Local).AddTicks(3115) });

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 13, 15, 3, 29, 35, DateTimeKind.Local).AddTicks(3116), new DateTime(2022, 1, 13, 15, 3, 29, 35, DateTimeKind.Local).AddTicks(3116) });

            migrationBuilder.UpdateData(
                table: "RequestLogs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CompletedAt", "RequestedAt" },
                values: new object[] { new DateTime(2022, 1, 13, 15, 3, 29, 35, DateTimeKind.Local).AddTicks(3225), new DateTime(2022, 1, 13, 15, 3, 29, 35, DateTimeKind.Local).AddTicks(3223) });

            migrationBuilder.UpdateData(
                table: "RequestLogs",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CompletedAt", "RequestedAt" },
                values: new object[] { new DateTime(2022, 1, 13, 15, 3, 29, 35, DateTimeKind.Local).AddTicks(3227), new DateTime(2022, 1, 13, 15, 3, 29, 35, DateTimeKind.Local).AddTicks(3226) });

            migrationBuilder.UpdateData(
                table: "RequestLogs",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CompletedAt", "RequestedAt" },
                values: new object[] { new DateTime(2022, 1, 13, 15, 3, 29, 35, DateTimeKind.Local).AddTicks(3228), new DateTime(2022, 1, 13, 15, 3, 29, 35, DateTimeKind.Local).AddTicks(3228) });

            migrationBuilder.UpdateData(
                table: "TaskAssignmentsLogs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CompletedAt", "CreatedAt" },
                values: new object[] { new DateTime(2022, 1, 13, 15, 3, 29, 35, DateTimeKind.Local).AddTicks(3257), new DateTime(2022, 1, 13, 15, 3, 29, 35, DateTimeKind.Local).AddTicks(3256) });

            migrationBuilder.UpdateData(
                table: "TaskAssignmentsLogs",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CompletedAt", "CreatedAt" },
                values: new object[] { new DateTime(2022, 1, 13, 15, 3, 29, 35, DateTimeKind.Local).AddTicks(3259), new DateTime(2022, 1, 13, 15, 3, 29, 35, DateTimeKind.Local).AddTicks(3258) });

            migrationBuilder.UpdateData(
                table: "TaskAssignmentsLogs",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CompletedAt", "CreatedAt" },
                values: new object[] { new DateTime(2022, 1, 13, 15, 3, 29, 35, DateTimeKind.Local).AddTicks(3260), new DateTime(2022, 1, 13, 15, 3, 29, 35, DateTimeKind.Local).AddTicks(3260) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "TaskDeadline", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 13, 15, 3, 29, 35, DateTimeKind.Local).AddTicks(3207), new DateTime(2022, 1, 13, 15, 3, 29, 35, DateTimeKind.Local).AddTicks(3208), new DateTime(2022, 1, 13, 15, 3, 29, 35, DateTimeKind.Local).AddTicks(3207) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "TaskDeadline", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 13, 15, 3, 29, 35, DateTimeKind.Local).AddTicks(3209), new DateTime(2022, 1, 13, 15, 3, 29, 35, DateTimeKind.Local).AddTicks(3210), new DateTime(2022, 1, 13, 15, 3, 29, 35, DateTimeKind.Local).AddTicks(3210) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "TaskDeadline", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 13, 15, 3, 29, 35, DateTimeKind.Local).AddTicks(3211), new DateTime(2022, 1, 13, 15, 3, 29, 35, DateTimeKind.Local).AddTicks(3212), new DateTime(2022, 1, 13, 15, 3, 29, 35, DateTimeKind.Local).AddTicks(3211) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TaskDeadline",
                table: "Tasks");

            migrationBuilder.UpdateData(
                table: "ExceptionLogs",
                keyColumn: "Id",
                keyValue: 1,
                column: "LoggedAt",
                value: new DateTime(2022, 1, 13, 11, 58, 36, 918, DateTimeKind.Local).AddTicks(1897));

            migrationBuilder.UpdateData(
                table: "ExceptionLogs",
                keyColumn: "Id",
                keyValue: 2,
                column: "LoggedAt",
                value: new DateTime(2022, 1, 13, 11, 58, 36, 918, DateTimeKind.Local).AddTicks(1898));

            migrationBuilder.UpdateData(
                table: "ExceptionLogs",
                keyColumn: "Id",
                keyValue: 3,
                column: "LoggedAt",
                value: new DateTime(2022, 1, 13, 11, 58, 36, 918, DateTimeKind.Local).AddTicks(1899));

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 13, 11, 58, 36, 918, DateTimeKind.Local).AddTicks(1707), new DateTime(2022, 1, 13, 11, 58, 36, 918, DateTimeKind.Local).AddTicks(1718) });

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 13, 11, 58, 36, 918, DateTimeKind.Local).AddTicks(1722), new DateTime(2022, 1, 13, 11, 58, 36, 918, DateTimeKind.Local).AddTicks(1722) });

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 13, 11, 58, 36, 918, DateTimeKind.Local).AddTicks(1723), new DateTime(2022, 1, 13, 11, 58, 36, 918, DateTimeKind.Local).AddTicks(1724) });

            migrationBuilder.UpdateData(
                table: "RequestLogs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CompletedAt", "RequestedAt" },
                values: new object[] { new DateTime(2022, 1, 13, 11, 58, 36, 918, DateTimeKind.Local).AddTicks(1881), new DateTime(2022, 1, 13, 11, 58, 36, 918, DateTimeKind.Local).AddTicks(1880) });

            migrationBuilder.UpdateData(
                table: "RequestLogs",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CompletedAt", "RequestedAt" },
                values: new object[] { new DateTime(2022, 1, 13, 11, 58, 36, 918, DateTimeKind.Local).AddTicks(1883), new DateTime(2022, 1, 13, 11, 58, 36, 918, DateTimeKind.Local).AddTicks(1882) });

            migrationBuilder.UpdateData(
                table: "RequestLogs",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CompletedAt", "RequestedAt" },
                values: new object[] { new DateTime(2022, 1, 13, 11, 58, 36, 918, DateTimeKind.Local).AddTicks(1884), new DateTime(2022, 1, 13, 11, 58, 36, 918, DateTimeKind.Local).AddTicks(1883) });

            migrationBuilder.UpdateData(
                table: "TaskAssignmentsLogs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CompletedAt", "CreatedAt" },
                values: new object[] { new DateTime(2022, 1, 13, 11, 58, 36, 918, DateTimeKind.Local).AddTicks(1910), new DateTime(2022, 1, 13, 11, 58, 36, 918, DateTimeKind.Local).AddTicks(1909) });

            migrationBuilder.UpdateData(
                table: "TaskAssignmentsLogs",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CompletedAt", "CreatedAt" },
                values: new object[] { new DateTime(2022, 1, 13, 11, 58, 36, 918, DateTimeKind.Local).AddTicks(1912), new DateTime(2022, 1, 13, 11, 58, 36, 918, DateTimeKind.Local).AddTicks(1911) });

            migrationBuilder.UpdateData(
                table: "TaskAssignmentsLogs",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CompletedAt", "CreatedAt" },
                values: new object[] { new DateTime(2022, 1, 13, 11, 58, 36, 918, DateTimeKind.Local).AddTicks(1913), new DateTime(2022, 1, 13, 11, 58, 36, 918, DateTimeKind.Local).AddTicks(1913) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 13, 11, 58, 36, 918, DateTimeKind.Local).AddTicks(1863), new DateTime(2022, 1, 13, 11, 58, 36, 918, DateTimeKind.Local).AddTicks(1864) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 13, 11, 58, 36, 918, DateTimeKind.Local).AddTicks(1865), new DateTime(2022, 1, 13, 11, 58, 36, 918, DateTimeKind.Local).AddTicks(1866) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 13, 11, 58, 36, 918, DateTimeKind.Local).AddTicks(1867), new DateTime(2022, 1, 13, 11, 58, 36, 918, DateTimeKind.Local).AddTicks(1867) });
        }
    }
}
