using System;
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

            migrationBuilder.CreateTable(
                name: "Memories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<float>(type: "real", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrandId = table.Column<int>(type: "int", nullable: true),
                    SeriesId = table.Column<int>(type: "int", nullable: true),
                    Category = table.Column<int>(type: "int", nullable: false),
                    NumberOfModules = table.Column<byte>(type: "tinyint", nullable: true),
                    CapacityPerModule = table.Column<int>(type: "int", nullable: true),
                    MemoryTypeId = table.Column<int>(type: "int", nullable: true),
                    MemorySpeedId = table.Column<int>(type: "int", nullable: true),
                    ColumnAddressStrobeLatency = table.Column<float>(type: "real", nullable: true),
                    Timings = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Voltage = table.Column<float>(type: "real", nullable: true),
                    HeatSpreader = table.Column<bool>(type: "bit", nullable: true),
                    Features = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstAvailable = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Memories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Memories_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Memories_MemorySpeeds_MemorySpeedId",
                        column: x => x.MemorySpeedId,
                        principalTable: "MemorySpeeds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Memories_MemoryTypes_MemoryTypeId",
                        column: x => x.MemoryTypeId,
                        principalTable: "MemoryTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Memories_Series_SeriesId",
                        column: x => x.SeriesId,
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Memories_BrandId",
                table: "Memories",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Memories_IsDeleted",
                table: "Memories",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Memories_MemorySpeedId",
                table: "Memories",
                column: "MemorySpeedId");

            migrationBuilder.CreateIndex(
                name: "IX_Memories_MemoryTypeId",
                table: "Memories",
                column: "MemoryTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Memories_SeriesId",
                table: "Memories",
                column: "SeriesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Memories");

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
