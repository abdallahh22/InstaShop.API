using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCouponTableConfigurations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_couponUsers_Coupons_CouponId",
                table: "couponUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_couponUsers",
                table: "couponUsers");

            migrationBuilder.DropIndex(
                name: "IX_couponUsers_CouponId",
                table: "couponUsers");

            migrationBuilder.RenameTable(
                name: "couponUsers",
                newName: "CouponUsers");

            migrationBuilder.AlterColumn<int>(
                name: "CouponId",
                table: "CouponUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CouponUsers",
                table: "CouponUsers",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_CouponUsers_CouponId",
                table: "CouponUsers",
                column: "CouponId",
                unique: true,
                filter: "[CouponId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_CouponUsers_Coupons_CouponId",
                table: "CouponUsers",
                column: "CouponId",
                principalTable: "Coupons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CouponUsers_Coupons_CouponId",
                table: "CouponUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CouponUsers",
                table: "CouponUsers");

            migrationBuilder.DropIndex(
                name: "IX_CouponUsers_CouponId",
                table: "CouponUsers");

            migrationBuilder.RenameTable(
                name: "CouponUsers",
                newName: "couponUsers");

            migrationBuilder.AlterColumn<int>(
                name: "CouponId",
                table: "couponUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_couponUsers",
                table: "couponUsers",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_couponUsers_CouponId",
                table: "couponUsers",
                column: "CouponId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_couponUsers_Coupons_CouponId",
                table: "couponUsers",
                column: "CouponId",
                principalTable: "Coupons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
