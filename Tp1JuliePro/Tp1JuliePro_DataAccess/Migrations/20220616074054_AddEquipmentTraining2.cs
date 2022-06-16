using Microsoft.EntityFrameworkCore.Migrations;

namespace Tp1JuliePro_DataAccess.Migrations
{
    public partial class AddEquipmentTraining2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Vélo" },
                    { 2, "Ensemble dumbels" },
                    { 3, "Tapis" },
                    { 4, "Step" },
                    { 5, "Ensemble barre altère" },
                    { 6, "Bloc yoga" },
                    { 7, "Elastiques" },
                    { 8, "Ballon d'exercice" }
                });

            migrationBuilder.InsertData(
                table: "Training",
                columns: new[] { "Id", "Category", "Name" },
                values: new object[,]
                {
                    { 1, "Cardio", "Step" },
                    { 2, "Étirement", "Yoga" },
                    { 3, "Musculaire", "CrossFit" },
                    { 4, "Cardio", "Course" },
                    { 5, "Cardio", "Zumba" },
                    { 6, "Musculaire", "Spinning" },
                    { 7, "Étirement", "Taichi" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Training",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Training",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Training",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Training",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Training",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Training",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Training",
                keyColumn: "Id",
                keyValue: 7);
        }
    }
}
