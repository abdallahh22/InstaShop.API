using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRateTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Rates",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rates_AppUserId",
                table: "Rates",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rates_AspNetUsers_AppUserId",
                table: "Rates",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rates_AspNetUsers_AppUserId",
                table: "Rates");

            migrationBuilder.DropIndex(
                name: "IX_Rates_AppUserId",
                table: "Rates");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Rates");
        }
    }
}
