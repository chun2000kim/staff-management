using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StaffManagement.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataToDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Staffs",
                columns: new[] { "StaffId", "Birthday", "FullName", "Gender" },
                values: new object[,]
                {
                    { "SF00001", new DateOnly(2000, 1, 1), "Staff 1", 1 },
                    { "SF00002", new DateOnly(1995, 5, 30), "Staff 2", 2 },
                    { "SF00003", new DateOnly(1999, 2, 15), "Staff 3", 1 },
                    { "SF00004", new DateOnly(2001, 1, 25), "Staff 4", 1 },
                    { "SF00005", new DateOnly(2001, 1, 25), "Staff 5", 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Staffs",
                keyColumn: "StaffId",
                keyValue: "SF00001");

            migrationBuilder.DeleteData(
                table: "Staffs",
                keyColumn: "StaffId",
                keyValue: "SF00002");

            migrationBuilder.DeleteData(
                table: "Staffs",
                keyColumn: "StaffId",
                keyValue: "SF00003");

            migrationBuilder.DeleteData(
                table: "Staffs",
                keyColumn: "StaffId",
                keyValue: "SF00004");

            migrationBuilder.DeleteData(
                table: "Staffs",
                keyColumn: "StaffId",
                keyValue: "SF00005");
        }
    }
}
