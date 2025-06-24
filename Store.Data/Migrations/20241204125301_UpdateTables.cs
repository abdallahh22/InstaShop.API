using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryDrivers_AspNetUsers_AppUserId",
                table: "DeliveryDrivers");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_DeliveryDrivers_DeliveryId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DeliveryDrivers",
                table: "DeliveryDrivers");

            migrationBuilder.DropColumn(
                name: "Name_Ar",
                table: "StoreTypes");

            migrationBuilder.DropColumn(
                name: "Name_Ar",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "Name_Ar",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Name_Ar",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Name_En",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "Name_Ar",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "Name_En",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "Name_Ar",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "DeliveryDrivers",
                newName: "Drivers");

            migrationBuilder.RenameColumn(
                name: "Name_En",
                table: "StoreTypes",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Name_En",
                table: "Stores",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Name_En",
                table: "Products",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Name_En",
                table: "Categories",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Name_En",
                table: "Drivers",
                newName: "PersonalId");

            migrationBuilder.RenameColumn(
                name: "Name_Ar",
                table: "Drivers",
                newName: "Name");

            migrationBuilder.RenameIndex(
                name: "IX_DeliveryDrivers_AppUserId",
                table: "Drivers",
                newName: "IX_Drivers_AppUserId");

            migrationBuilder.AddColumn<string>(
                name: "DriverLicens",
                table: "Drivers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Drivers",
                table: "Drivers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Drivers_AspNetUsers_AppUserId",
                table: "Drivers",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Drivers_DeliveryId",
                table: "Orders",
                column: "DeliveryId",
                principalTable: "Drivers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drivers_AspNetUsers_AppUserId",
                table: "Drivers");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Drivers_DeliveryId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Drivers",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "DriverLicens",
                table: "Drivers");

            migrationBuilder.RenameTable(
                name: "Drivers",
                newName: "DeliveryDrivers");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "StoreTypes",
                newName: "Name_En");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Stores",
                newName: "Name_En");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Products",
                newName: "Name_En");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Categories",
                newName: "Name_En");

            migrationBuilder.RenameColumn(
                name: "PersonalId",
                table: "DeliveryDrivers",
                newName: "Name_En");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "DeliveryDrivers",
                newName: "Name_Ar");

            migrationBuilder.RenameIndex(
                name: "IX_Drivers_AppUserId",
                table: "DeliveryDrivers",
                newName: "IX_DeliveryDrivers_AppUserId");

            migrationBuilder.AddColumn<string>(
                name: "Name_Ar",
                table: "StoreTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name_Ar",
                table: "Stores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name_Ar",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Orders",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name_Ar",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name_En",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "OrderItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "OrderItems",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name_Ar",
                table: "OrderItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name_En",
                table: "OrderItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name_Ar",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeliveryDrivers",
                table: "DeliveryDrivers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryDrivers_AspNetUsers_AppUserId",
                table: "DeliveryDrivers",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_DeliveryDrivers_DeliveryId",
                table: "Orders",
                column: "DeliveryId",
                principalTable: "DeliveryDrivers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
