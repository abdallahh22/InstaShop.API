using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBaseEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                table: "Offers",
                newName: "Name_En");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Categories",
                newName: "Name_En");

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

            migrationBuilder.AddColumn<string>(
                name: "Name_Ar",
                table: "Offers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name_Ar",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "Name_Ar",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "Name_Ar",
                table: "Categories");

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
                table: "Offers",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Name_En",
                table: "Categories",
                newName: "Name");
        }
    }
}
