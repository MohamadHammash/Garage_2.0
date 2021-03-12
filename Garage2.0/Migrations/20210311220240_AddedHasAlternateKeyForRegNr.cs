using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Garage2._0.Migrations
{
    public partial class AddedHasAlternateKeyForRegNr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RegNr",
                table: "ParkedVehicle",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_ParkedVehicle_RegNr",
                table: "ParkedVehicle",
                column: "RegNr");

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 1,
                column: "ArrivalTime",
                value: new DateTime(2021, 3, 11, 8, 15, 30, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ArrivalTime", "Brand", "Model" },
                values: new object[] { new DateTime(2021, 3, 11, 16, 25, 0, 0, DateTimeKind.Unspecified), "Toyota", "Corolla" });

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 3,
                column: "ArrivalTime",
                value: new DateTime(2021, 3, 11, 21, 10, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 4,
                column: "ArrivalTime",
                value: new DateTime(2021, 3, 11, 22, 2, 40, 70, DateTimeKind.Local).AddTicks(2072));

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 5,
                column: "ArrivalTime",
                value: new DateTime(2021, 3, 11, 22, 32, 40, 73, DateTimeKind.Local).AddTicks(7216));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_ParkedVehicle_RegNr",
                table: "ParkedVehicle");

            migrationBuilder.AlterColumn<string>(
                name: "RegNr",
                table: "ParkedVehicle",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 1,
                column: "ArrivalTime",
                value: new DateTime(2020, 12, 25, 8, 15, 30, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ArrivalTime", "Brand", "Model" },
                values: new object[] { new DateTime(2020, 12, 31, 16, 25, 0, 0, DateTimeKind.Unspecified), "", "" });

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 3,
                column: "ArrivalTime",
                value: new DateTime(2021, 3, 10, 21, 10, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 4,
                column: "ArrivalTime",
                value: new DateTime(2021, 3, 9, 22, 15, 8, 480, DateTimeKind.Local).AddTicks(752));

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 5,
                column: "ArrivalTime",
                value: new DateTime(2021, 3, 11, 9, 4, 56, 485, DateTimeKind.Local).AddTicks(4690));
        }
    }
}
