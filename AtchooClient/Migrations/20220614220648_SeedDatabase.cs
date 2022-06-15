using Microsoft.EntityFrameworkCore.Migrations;

namespace AtchooClient.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UserAllergies",
                columns: new[] { "UserAllergyId", "Allergy" },
                values: new object[,]
                {
                    { 1, "Lactose Intolerant" },
                    { 2, "Pollen" },
                    { 3, "Dust" },
                    { 4, "Shellfish" },
                    { 5, "Peanuts" },
                    { 6, "Pet Fur" },
                    { 7, "Perfumes" },
                    { 8, "Insects" },
                    { 9, "Soy" },
                    { 10, "Gluten" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserAllergies",
                keyColumn: "UserAllergyId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserAllergies",
                keyColumn: "UserAllergyId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UserAllergies",
                keyColumn: "UserAllergyId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "UserAllergies",
                keyColumn: "UserAllergyId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "UserAllergies",
                keyColumn: "UserAllergyId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "UserAllergies",
                keyColumn: "UserAllergyId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "UserAllergies",
                keyColumn: "UserAllergyId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "UserAllergies",
                keyColumn: "UserAllergyId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "UserAllergies",
                keyColumn: "UserAllergyId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "UserAllergies",
                keyColumn: "UserAllergyId",
                keyValue: 10);
        }
    }
}
