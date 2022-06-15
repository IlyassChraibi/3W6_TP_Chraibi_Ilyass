using Microsoft.EntityFrameworkCore.Migrations;

namespace Tp1JuliePro_DataAccess.Migrations
{
    public partial class updateSpecialityTrainer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Trainer",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Speciality_Id",
                table: "Trainer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Speciality",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Perte de poids" },
                    { 2, "Course" },
                    { 3, "Althérophilie" },
                    { 4, "Réhabilitation" }
                });

            migrationBuilder.InsertData(
                table: "Trainer",
                columns: new[] { "Id", "Active", "Email", "FirstName", "LastName", "Photo", "Speciality_Id" },
                values: new object[,]
                {
                    { 1, true, "Chrystal.lapierre@juliepro.ca", "Chrysal", "Lappierre", "8624af64-2685-459a-a1cc-816c0695d760.png", 1 },
                    { 3, false, "Frank.StJohn@juliepro.ca", "François", "Saint-John", "aedd9532-1395-42a2-8ae6-56f0e2ab49b5.png", 1 },
                    { 2, true, "Felix.trudeau@juliePro.ca", "Félix", "Trudeau", "a202bae3-e6bb-40f0-84cf-e4b11627ba1c.png", 2 },
                    { 6, true, "Karine.Lachance@juliepro.ca", "Karine", "Lachance", "b333bae3-e6bb-40f0-84cf-e4b11627ba1c.png", 2 },
                    { 5, true, "JinLee.godette@juliepro.ca", "Jin Lee", "Godette", "E3Rcc6d9-0599-42aa-8305-3c1ae5a4512v.png", 3 },
                    { 7, false, "Ramone.Esteban@juliepro.ca", "Ramone", "Esteban", "waqd9532-1395-42a2-8ae6-56f0e2ab49e9.png", 3 },
                    { 4, true, "JC.Bastien@juliepro.ca", "Jean-Claude", "Bastien", "d7bcc6d9-0599-42aa-8305-3c1ae5a4505c.png", 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trainer_Speciality_Id",
                table: "Trainer",
                column: "Speciality_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Trainer_Speciality_Speciality_Id",
                table: "Trainer",
                column: "Speciality_Id",
                principalTable: "Speciality",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trainer_Speciality_Speciality_Id",
                table: "Trainer");

            migrationBuilder.DropIndex(
                name: "IX_Trainer_Speciality_Id",
                table: "Trainer");

            migrationBuilder.DeleteData(
                table: "Trainer",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Trainer",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Trainer",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Trainer",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Trainer",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Trainer",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Trainer",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Speciality",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Speciality",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Speciality",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Speciality",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Trainer");

            migrationBuilder.DropColumn(
                name: "Speciality_Id",
                table: "Trainer");
        }
    }
}
