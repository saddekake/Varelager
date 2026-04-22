using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Varelager.ApiService.Migrations
{
    /// <inheritdoc />
    public partial class AddAuth0UserId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Auth0UserId",
                table: "Account",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Account_Auth0UserId",
                table: "Account",
                column: "Auth0UserId",
                unique: true,
                filter: "[Auth0UserId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Account_Auth0UserId",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "Auth0UserId",
                table: "Account");
        }
    }
}
