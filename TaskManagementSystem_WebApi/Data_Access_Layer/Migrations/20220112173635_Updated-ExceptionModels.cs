using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data_Access_Layer.Migrations
{
    public partial class UpdatedExceptionModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Route",
                table: "ExceptionLogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "ExceptionLogs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "LoggedAt", "Route" },
                values: new object[] { new DateTime(2022, 1, 12, 23, 36, 34, 885, DateTimeKind.Local).AddTicks(8675), "api/person" });

            migrationBuilder.UpdateData(
                table: "ExceptionLogs",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "LoggedAt", "Route" },
                values: new object[] { new DateTime(2022, 1, 12, 23, 36, 34, 885, DateTimeKind.Local).AddTicks(8676), "api/task/" });

            migrationBuilder.UpdateData(
                table: "ExceptionLogs",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "LoggedAt", "Route" },
                values: new object[] { new DateTime(2022, 1, 12, 23, 36, 34, 885, DateTimeKind.Local).AddTicks(8677), "api/person" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Route",
                table: "ExceptionLogs");

            migrationBuilder.UpdateData(
                table: "ExceptionLogs",
                keyColumn: "Id",
                keyValue: 1,
                column: "LoggedAt",
                value: new DateTime(2022, 1, 11, 19, 40, 31, 921, DateTimeKind.Local).AddTicks(7802));

            migrationBuilder.UpdateData(
                table: "ExceptionLogs",
                keyColumn: "Id",
                keyValue: 2,
                column: "LoggedAt",
                value: new DateTime(2022, 1, 11, 19, 40, 31, 921, DateTimeKind.Local).AddTicks(7803));

            migrationBuilder.UpdateData(
                table: "ExceptionLogs",
                keyColumn: "Id",
                keyValue: 3,
                column: "LoggedAt",
                value: new DateTime(2022, 1, 11, 19, 40, 31, 921, DateTimeKind.Local).AddTicks(7804));

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 11, 19, 40, 31, 921, DateTimeKind.Local).AddTicks(7615), new DateTime(2022, 1, 11, 19, 40, 31, 921, DateTimeKind.Local).AddTicks(7625) });

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 11, 19, 40, 31, 921, DateTimeKind.Local).AddTicks(7628), new DateTime(2022, 1, 11, 19, 40, 31, 921, DateTimeKind.Local).AddTicks(7629) });

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 11, 19, 40, 31, 921, DateTimeKind.Local).AddTicks(7629), new DateTime(2022, 1, 11, 19, 40, 31, 921, DateTimeKind.Local).AddTicks(7630) });

            migrationBuilder.UpdateData(
                table: "RequestLogs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CompletedAt", "RequestedAt" },
                values: new object[] { new DateTime(2022, 1, 11, 19, 40, 31, 921, DateTimeKind.Local).AddTicks(7787), new DateTime(2022, 1, 11, 19, 40, 31, 921, DateTimeKind.Local).AddTicks(7787) });

            migrationBuilder.UpdateData(
                table: "RequestLogs",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CompletedAt", "RequestedAt" },
                values: new object[] { new DateTime(2022, 1, 11, 19, 40, 31, 921, DateTimeKind.Local).AddTicks(7789), new DateTime(2022, 1, 11, 19, 40, 31, 921, DateTimeKind.Local).AddTicks(7788) });

            migrationBuilder.UpdateData(
                table: "RequestLogs",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CompletedAt", "RequestedAt" },
                values: new object[] { new DateTime(2022, 1, 11, 19, 40, 31, 921, DateTimeKind.Local).AddTicks(7790), new DateTime(2022, 1, 11, 19, 40, 31, 921, DateTimeKind.Local).AddTicks(7790) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 11, 19, 40, 31, 921, DateTimeKind.Local).AddTicks(7720), new DateTime(2022, 1, 11, 19, 40, 31, 921, DateTimeKind.Local).AddTicks(7720) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 11, 19, 40, 31, 921, DateTimeKind.Local).AddTicks(7722), new DateTime(2022, 1, 11, 19, 40, 31, 921, DateTimeKind.Local).AddTicks(7722) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 11, 19, 40, 31, 921, DateTimeKind.Local).AddTicks(7723), new DateTime(2022, 1, 11, 19, 40, 31, 921, DateTimeKind.Local).AddTicks(7724) });
        }
    }
}
