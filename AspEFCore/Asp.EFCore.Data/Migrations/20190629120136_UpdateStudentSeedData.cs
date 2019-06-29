using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Asp.EFCore.Data.Migrations
{
    public partial class UpdateStudentSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "Id",
                keyValue: new Guid("170e3505-f717-4201-8a9e-6a592ab358e4"));

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("ed5dfd31-db05-49b2-859c-b48a1062ba99"), "曹操" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "Id",
                keyValue: new Guid("ed5dfd31-db05-49b2-859c-b48a1062ba99"));

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("170e3505-f717-4201-8a9e-6a592ab358e4"), "刘备" });
        }
    }
}
