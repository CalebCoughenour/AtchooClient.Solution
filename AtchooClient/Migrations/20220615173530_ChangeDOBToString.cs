using Microsoft.EntityFrameworkCore.Migrations;

namespace AtchooClient.Migrations
{
    public partial class ChangeDOBToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserProfiles",
                keyColumn: "UserProfileId",
                keyValue: 1);

            migrationBuilder.AlterColumn<string>(
                name: "DOB",
                table: "UserProfiles",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "DOB",
                table: "UserProfiles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "UserProfiles",
                columns: new[] { "UserProfileId", "Bio", "DOB", "Name", "ProfileImg", "UserId" },
                values: new object[] { 1, "Just a dude", 10119999, "John Doe", "https://ibb.co/RcdCV40", null });
        }
    }
}
