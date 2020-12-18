using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PCP.Data.Migrations
{
    public partial class AddHDDAndSateliteTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GPUs_GPUInterfaces_GPUInterfaceId",
                table: "GPUs");

            migrationBuilder.DropTable(
                name: "GPUInterfaces");

            migrationBuilder.AlterColumn<bool>(
                name: "HeatSpreader",
                table: "Memories",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "HDDUsages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HDDUsages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Interfaces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interfaces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HDDs",
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
                    InterfaceId = table.Column<int>(type: "int", nullable: true),
                    CapacityGb = table.Column<short>(type: "smallint", nullable: true),
                    RevolutionsPerMinute = table.Column<short>(type: "smallint", nullable: true),
                    CacheKb = table.Column<short>(type: "smallint", nullable: true),
                    Features = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsageId = table.Column<int>(type: "int", nullable: true),
                    FormFactorId = table.Column<int>(type: "int", nullable: true),
                    Height = table.Column<float>(type: "real", nullable: true),
                    Width = table.Column<float>(type: "real", nullable: true),
                    Length = table.Column<float>(type: "real", nullable: true),
                    FirstAvailable = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HDDs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HDDs_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HDDs_FormFactors_FormFactorId",
                        column: x => x.FormFactorId,
                        principalTable: "FormFactors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HDDs_HDDUsages_UsageId",
                        column: x => x.UsageId,
                        principalTable: "HDDUsages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HDDs_Interfaces_InterfaceId",
                        column: x => x.InterfaceId,
                        principalTable: "Interfaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HDDs_Series_SeriesId",
                        column: x => x.SeriesId,
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HDDs_BrandId",
                table: "HDDs",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_HDDs_FormFactorId",
                table: "HDDs",
                column: "FormFactorId");

            migrationBuilder.CreateIndex(
                name: "IX_HDDs_InterfaceId",
                table: "HDDs",
                column: "InterfaceId");

            migrationBuilder.CreateIndex(
                name: "IX_HDDs_IsDeleted",
                table: "HDDs",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_HDDs_SeriesId",
                table: "HDDs",
                column: "SeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_HDDs_UsageId",
                table: "HDDs",
                column: "UsageId");

            migrationBuilder.CreateIndex(
                name: "IX_HDDUsages_IsDeleted",
                table: "HDDUsages",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Interfaces_IsDeleted",
                table: "Interfaces",
                column: "IsDeleted");

            migrationBuilder.AddForeignKey(
                name: "FK_GPUs_Interfaces_GPUInterfaceId",
                table: "GPUs",
                column: "GPUInterfaceId",
                principalTable: "Interfaces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GPUs_Interfaces_GPUInterfaceId",
                table: "GPUs");

            migrationBuilder.DropTable(
                name: "HDDs");

            migrationBuilder.DropTable(
                name: "HDDUsages");

            migrationBuilder.DropTable(
                name: "Interfaces");

            migrationBuilder.AlterColumn<bool>(
                name: "HeatSpreader",
                table: "Memories",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.CreateTable(
                name: "GPUInterfaces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GPUInterfaces", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GPUInterfaces_IsDeleted",
                table: "GPUInterfaces",
                column: "IsDeleted");

            migrationBuilder.AddForeignKey(
                name: "FK_GPUs_GPUInterfaces_GPUInterfaceId",
                table: "GPUs",
                column: "GPUInterfaceId",
                principalTable: "GPUInterfaces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
