using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data_Access_Layer.Migrations
{
    public partial class TaskAssignmentTableCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Tasks",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Tasks",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Route",
                table: "RequestLogs",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Persons",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Route",
                table: "ExceptionLogs",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "TaskAssignmentsLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompletedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TaskId = table.Column<int>(type: "int", nullable: false),
                    AssignedById = table.Column<int>(type: "int", nullable: false),
                    AssignedToId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskAssignmentsLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskAssignmentsLogs_Persons_AssignedById",
                        column: x => x.AssignedById,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TaskAssignmentsLogs_Persons_AssignedToId",
                        column: x => x.AssignedToId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TaskAssignmentsLogs_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.InsertData(
                table: "TaskAssignmentsLogs",
                columns: new[] { "Id", "AssignedById", "AssignedToId", "CompletedAt", "CreatedAt", "Status", "TaskId" },
                values: new object[,]
                {
                    { 1, 1, 2, new DateTime(2022, 1, 13, 11, 58, 36, 918, DateTimeKind.Local).AddTicks(1910), new DateTime(2022, 1, 13, 11, 58, 36, 918, DateTimeKind.Local).AddTicks(1909), "Pending", 1 },
                    { 2, 3, 2, new DateTime(2022, 1, 13, 11, 58, 36, 918, DateTimeKind.Local).AddTicks(1912), new DateTime(2022, 1, 13, 11, 58, 36, 918, DateTimeKind.Local).AddTicks(1911), "Pending", 2 },
                    { 3, 1, 3, new DateTime(2022, 1, 13, 11, 58, 36, 918, DateTimeKind.Local).AddTicks(1913), new DateTime(2022, 1, 13, 11, 58, 36, 918, DateTimeKind.Local).AddTicks(1913), "Completed", 3 }
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_TaskAssignmentsLogs_AssignedById",
                table: "TaskAssignmentsLogs",
                column: "AssignedById");

            migrationBuilder.CreateIndex(
                name: "IX_TaskAssignmentsLogs_AssignedToId",
                table: "TaskAssignmentsLogs",
                column: "AssignedToId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskAssignmentsLogs_TaskId",
                table: "TaskAssignmentsLogs",
                column: "TaskId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskAssignmentsLogs");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Tasks",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Tasks",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);

            migrationBuilder.AlterColumn<string>(
                name: "Route",
                table: "RequestLogs",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Route",
                table: "ExceptionLogs",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);

            migrationBuilder.UpdateData(
                table: "ExceptionLogs",
                keyColumn: "Id",
                keyValue: 1,
                column: "LoggedAt",
                value: new DateTime(2022, 1, 12, 23, 36, 34, 885, DateTimeKind.Local).AddTicks(8675));

            migrationBuilder.UpdateData(
                table: "ExceptionLogs",
                keyColumn: "Id",
                keyValue: 2,
                column: "LoggedAt",
                value: new DateTime(2022, 1, 12, 23, 36, 34, 885, DateTimeKind.Local).AddTicks(8676));

            migrationBuilder.UpdateData(
                table: "ExceptionLogs",
                keyColumn: "Id",
                keyValue: 3,
                column: "LoggedAt",
                value: new DateTime(2022, 1, 12, 23, 36, 34, 885, DateTimeKind.Local).AddTicks(8677));

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 12, 23, 36, 34, 885, DateTimeKind.Local).AddTicks(8532), new DateTime(2022, 1, 12, 23, 36, 34, 885, DateTimeKind.Local).AddTicks(8541) });

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 12, 23, 36, 34, 885, DateTimeKind.Local).AddTicks(8544), new DateTime(2022, 1, 12, 23, 36, 34, 885, DateTimeKind.Local).AddTicks(8545) });

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 12, 23, 36, 34, 885, DateTimeKind.Local).AddTicks(8546), new DateTime(2022, 1, 12, 23, 36, 34, 885, DateTimeKind.Local).AddTicks(8546) });

            migrationBuilder.UpdateData(
                table: "RequestLogs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CompletedAt", "RequestedAt" },
                values: new object[] { new DateTime(2022, 1, 12, 23, 36, 34, 885, DateTimeKind.Local).AddTicks(8657), new DateTime(2022, 1, 12, 23, 36, 34, 885, DateTimeKind.Local).AddTicks(8657) });

            migrationBuilder.UpdateData(
                table: "RequestLogs",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CompletedAt", "RequestedAt" },
                values: new object[] { new DateTime(2022, 1, 12, 23, 36, 34, 885, DateTimeKind.Local).AddTicks(8659), new DateTime(2022, 1, 12, 23, 36, 34, 885, DateTimeKind.Local).AddTicks(8658) });

            migrationBuilder.UpdateData(
                table: "RequestLogs",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CompletedAt", "RequestedAt" },
                values: new object[] { new DateTime(2022, 1, 12, 23, 36, 34, 885, DateTimeKind.Local).AddTicks(8660), new DateTime(2022, 1, 12, 23, 36, 34, 885, DateTimeKind.Local).AddTicks(8660) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 12, 23, 36, 34, 885, DateTimeKind.Local).AddTicks(8641), new DateTime(2022, 1, 12, 23, 36, 34, 885, DateTimeKind.Local).AddTicks(8642) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 12, 23, 36, 34, 885, DateTimeKind.Local).AddTicks(8643), new DateTime(2022, 1, 12, 23, 36, 34, 885, DateTimeKind.Local).AddTicks(8644) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 12, 23, 36, 34, 885, DateTimeKind.Local).AddTicks(8644), new DateTime(2022, 1, 12, 23, 36, 34, 885, DateTimeKind.Local).AddTicks(8645) });
        }
    }
}
