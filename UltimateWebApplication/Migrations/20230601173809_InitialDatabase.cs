using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UltimateWebApplication.Migrations
{
    /// <inheritdoc />
    public partial class InitialDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                columns: new[] { "DateOfBirth", "Position" },
                values: new object[] { new DateTime(2023, 6, 1, 18, 38, 9, 727, DateTimeKind.Local).AddTicks(1530), "Software Dev" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                columns: new[] { "DateOfBirth", "Position" },
                values: new object[] { new DateTime(2023, 6, 1, 17, 28, 42, 955, DateTimeKind.Local).AddTicks(7738), "Software-Dev" });
        }
    }
}
