using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTablesI : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Drivers_DeliveryId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Stores_StoreId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_StoreId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "DeliveryDate",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "DeliveryNotes",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "DeliveryTime",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "DriverLicens",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "DriverPhone",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "Invoice_photo",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Drivers");

            migrationBuilder.RenameColumn(
                name: "DeliveryId",
                table: "Orders",
                newName: "DriverId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_DeliveryId",
                table: "Orders",
                newName: "IX_Orders_DriverId");

            migrationBuilder.RenameColumn(
                name: "VehicleType",
                table: "Drivers",
                newName: "ProfilePhoto");

            migrationBuilder.RenameColumn(
                name: "VehicleNumber",
                table: "Drivers",
                newName: "PersonalId_Photo");

            migrationBuilder.RenameColumn(
                name: "PersonalId",
                table: "Drivers",
                newName: "LicenseId_Photo");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Drivers",
                newName: "FullName");

            migrationBuilder.RenameColumn(
                name: "DeliveryStatus",
                table: "Drivers",
                newName: "TruckId");

            migrationBuilder.AddColumn<DateTime>(
                name: "Dliver_Date",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Dliver_Time",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Invoice_photo",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsWorking",
                table: "Drivers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Coupons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Coupone_value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Coupone_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Is_Valied = table.Column<bool>(type: "bit", nullable: true),
                    Is_Deleted = table.Column<bool>(type: "bit", nullable: true),
                    Is_percent = table.Column<bool>(type: "bit", nullable: true),
                    StoreId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Coupons_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "couponUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CouponId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    Is_valid = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_couponUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_couponUsers_Coupons_CouponId",
                        column: x => x.CouponId,
                        principalTable: "Coupons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Coupons_StoreId",
                table: "Coupons",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_couponUsers_CouponId",
                table: "couponUsers",
                column: "CouponId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Drivers_DriverId",
                table: "Orders",
                column: "DriverId",
                principalTable: "Drivers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Drivers_DriverId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "couponUsers");

            migrationBuilder.DropTable(
                name: "Coupons");

            migrationBuilder.DropColumn(
                name: "Dliver_Date",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Dliver_Time",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Invoice_photo",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "IsWorking",
                table: "Drivers");

            migrationBuilder.RenameColumn(
                name: "DriverId",
                table: "Orders",
                newName: "DeliveryId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_DriverId",
                table: "Orders",
                newName: "IX_Orders_DeliveryId");

            migrationBuilder.RenameColumn(
                name: "TruckId",
                table: "Drivers",
                newName: "DeliveryStatus");

            migrationBuilder.RenameColumn(
                name: "ProfilePhoto",
                table: "Drivers",
                newName: "VehicleType");

            migrationBuilder.RenameColumn(
                name: "PersonalId_Photo",
                table: "Drivers",
                newName: "VehicleNumber");

            migrationBuilder.RenameColumn(
                name: "LicenseId_Photo",
                table: "Drivers",
                newName: "PersonalId");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Drivers",
                newName: "Name");

            migrationBuilder.AddColumn<int>(
                name: "StoreId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Drivers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeliveryDate",
                table: "Drivers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeliveryNotes",
                table: "Drivers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeliveryTime",
                table: "Drivers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DriverLicens",
                table: "Drivers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DriverPhone",
                table: "Drivers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Invoice_photo",
                table: "Drivers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Drivers",
                type: "bit",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_StoreId",
                table: "Products",
                column: "StoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Drivers_DeliveryId",
                table: "Orders",
                column: "DeliveryId",
                principalTable: "Drivers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Stores_StoreId",
                table: "Products",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
