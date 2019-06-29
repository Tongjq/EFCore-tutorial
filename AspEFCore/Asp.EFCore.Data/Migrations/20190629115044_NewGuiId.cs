using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Asp.EFCore.Data.Migrations
{
    public partial class NewGuiId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Provinces",
                columns: new[] { "Id", "Name", "Population" },
                values: new object[,]
                {
                    { 1, "甘肃省", 20000000 },
                    { 2, "陕西", 15000000 },
                    { 4, "山西", 17000000 }
                });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("170e3505-f717-4201-8a9e-6a592ab358e4"), "刘备" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "AreaCode", "Name", "ProvinceId" },
                values: new object[] { 61, null, "太原", 4 });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "AreaCode", "Name", "ProvinceId" },
                values: new object[] { 62, null, "大同", 4 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
