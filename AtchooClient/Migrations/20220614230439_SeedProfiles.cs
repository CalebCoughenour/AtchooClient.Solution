using Microsoft.EntityFrameworkCore.Migrations;

namespace AtchooClient.Migrations
{
    public partial class SeedProfiles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UserProfiles",
                columns: new[] { "UserProfileId", "Bio", "DOB", "Name", "ProfileImg", "UserId" },
                values: new object[] { 1, "Just a dude", 10119999, "John Doe", "https://ibb.co/RcdCV40", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserProfiles",
                keyColumn: "UserProfileId",
                keyValue: 1);
        }
    }
}
