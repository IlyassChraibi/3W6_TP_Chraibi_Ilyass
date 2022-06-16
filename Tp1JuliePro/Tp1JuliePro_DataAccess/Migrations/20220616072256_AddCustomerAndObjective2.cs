using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tp1JuliePro_DataAccess.Migrations
{
    public partial class AddCustomerAndObjective2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "BirthDate", "CustomerId", "Email", "FirstName", "LastName", "Photo", "StartWeight", "TrainerId" },
                values: new object[,]
                {
                    { 1, new DateTime(1965, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "arthurLaroche@gmail.com", "Arthur", "Laroche", "", null, 3 },
                    { 2, new DateTime(1965, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "DelimaCaillou@gmail.com", "Délima", "Caillou", "", null, 2 },
                    { 3, new DateTime(1965, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "fredcaillou@gmail.com", "Fred", "Caillou", "", null, 3 },
                    { 4, new DateTime(1965, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "berthaLaroche@gmail.com", "Bertha", "Laroche", "", null, 1 }
                });

            migrationBuilder.InsertData(
                table: "Objective",
                columns: new[] { "Id", "AchievedDate", "CustomerId", "DistanceKm", "LostWeight", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 0.0, 5.0, "" },
                    { 2, new DateTime(2021, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 0.0, 5.0, "" },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 0.0, 5.0, "" },
                    { 4, new DateTime(2022, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 0.0, 10.0, "" },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 0.0, 5.0, "" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Objective",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Objective",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Objective",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Objective",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Objective",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
