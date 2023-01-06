using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dataLayer.Migrations
{
    public partial class v15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "SensorData",
                columns: new[] { "Id", "Date", "SensorId", "Temperature" },
                values: new object[,]
                {
                    { 5, new DateTime(2022, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, -5 },
                    { 6, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 0 },
                    { 7, new DateTime(2023, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3 },
                    { 8, new DateTime(2023, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, -7 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SensorData",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "SensorData",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "SensorData",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "SensorData",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}
