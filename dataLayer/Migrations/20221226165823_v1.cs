using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dataLayer.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Region",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Region", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sensor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lon = table.Column<float>(type: "real", nullable: false),
                    Lat = table.Column<float>(type: "real", nullable: false),
                    RegionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sensor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sensor_Region_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Region",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SensorData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SensorId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Temperature = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SensorData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SensorData_Sensor_SensorId",
                        column: x => x.SensorId,
                        principalTable: "Sensor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Ludvinono" });

            migrationBuilder.InsertData(
                table: "Sensor",
                columns: new[] { "Id", "Lat", "Lon", "Name", "RegionId" },
                values: new object[] { 1, 54.570717f, 27.276983f, "TMP-1", 1 });

            migrationBuilder.InsertData(
                table: "SensorData",
                columns: new[] { "Id", "Date", "SensorId", "Temperature" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, -3 },
                    { 2, new DateTime(2022, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { 3, new DateTime(2022, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 4, new DateTime(2022, 12, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sensor_RegionId",
                table: "Sensor",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_SensorData_SensorId",
                table: "SensorData",
                column: "SensorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SensorData");

            migrationBuilder.DropTable(
                name: "Sensor");

            migrationBuilder.DropTable(
                name: "Region");
        }
    }
}
