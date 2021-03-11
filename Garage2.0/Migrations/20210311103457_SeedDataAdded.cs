using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Garage2._0.Migrations
{
    public partial class SeedDataAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ParkedVehicle",
                columns: new[] { "Id", "ArrivalTime", "Brand", "Color", "Model", "NrOfWheels", "RegNr", "VehicleType" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 12, 25, 8, 15, 30, 0, DateTimeKind.Unspecified), "Volvo", "Red", "XC40", 4, "ABC001", 0 },
                    { 2, new DateTime(2020, 12, 31, 16, 25, 0, 0, DateTimeKind.Unspecified), "", "Black", "", 4, "BCA321", 0 },
                    { 3, new DateTime(2021, 3, 10, 21, 10, 0, 0, DateTimeKind.Unspecified), "Harley Davidson", "Green", "Low rider", 2, "HDA555", 2 },
                    { 4, new DateTime(2021, 3, 9, 22, 15, 8, 480, DateTimeKind.Local).AddTicks(752), "Volkswagen", "Blue", "Golf", 4, "MLB11U", 0 },
                    { 5, new DateTime(2021, 3, 11, 9, 4, 56, 485, DateTimeKind.Local).AddTicks(4690), "Scania", "White", "L320", 4, "SCA777", 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
