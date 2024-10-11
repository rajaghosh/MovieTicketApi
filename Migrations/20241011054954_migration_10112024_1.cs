using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieTicketApi.Migrations
{
    /// <inheritdoc />
    public partial class migration_10112024_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "UserMaster",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "UserMaster",
                keyColumn: "Id",
                keyValue: 1,
                column: "Role",
                value: "Admin");

            migrationBuilder.UpdateData(
                table: "UserMaster",
                keyColumn: "Id",
                keyValue: 2,
                column: "Role",
                value: "Admin");

            migrationBuilder.UpdateData(
                table: "UserMaster",
                keyColumn: "Id",
                keyValue: 3,
                column: "Role",
                value: "User");

            migrationBuilder.UpdateData(
                table: "UserMaster",
                keyColumn: "Id",
                keyValue: 4,
                column: "Role",
                value: "User");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "UserMaster");
        }
    }
}
