using Microsoft.EntityFrameworkCore.Migrations;

namespace PCP.Data.Migrations
{
    public partial class AddMemoryTableAndAddCategoryToOtherMainTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "CPUs",
                newName: "Category");

            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "Motherboards",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "GPUs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Motherboards");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "GPUs");

            migrationBuilder.RenameColumn(
                name: "Category",
                table: "CPUs",
                newName: "Type");
        }
    }
}
