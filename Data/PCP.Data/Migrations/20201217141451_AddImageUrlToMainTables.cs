namespace PCP.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddImageUrlToMainTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Motherboards",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MemorySize",
                table: "GPUs",
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "GPUs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "CPUs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Motherboards");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "GPUs");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "CPUs");

            migrationBuilder.AlterColumn<short>(
                name: "MemorySize",
                table: "GPUs",
                type: "smallint",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
