using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateOrderTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Rates",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rates_OrderId",
                table: "Rates",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rates_Orders_OrderId",
                table: "Rates",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rates_Orders_OrderId",
                table: "Rates");

            migrationBuilder.DropIndex(
                name: "IX_Rates_OrderId",
                table: "Rates");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Rates");
        }
    }
}
