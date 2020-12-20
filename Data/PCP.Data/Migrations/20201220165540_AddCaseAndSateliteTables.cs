using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PCP.Data.Migrations
{
    public partial class AddCaseAndSateliteTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CPUAirCoolers_Color_ColorId",
                table: "CPUAirCoolers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Color",
                table: "Color");

            migrationBuilder.RenameTable(
                name: "Color",
                newName: "Colors");

            migrationBuilder.RenameIndex(
                name: "IX_Color_IsDeleted",
                table: "Colors",
                newName: "IX_Colors_IsDeleted");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Colors",
                table: "Colors",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CaseTypes",
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
                    table.PrimaryKey("PK_CaseTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Materials",
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
                    table.PrimaryKey("PK_Materials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cases",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CaseTypeId = table.Column<int>(type: "int", nullable: true),
                    ColorId = table.Column<int>(type: "int", nullable: true),
                    HasPowerSupply = table.Column<bool>(type: "bit", nullable: true),
                    CasePowerSupplyPosition = table.Column<int>(type: "int", nullable: false),
                    SidePanelWindow = table.Column<bool>(type: "bit", nullable: true),
                    DustFilters = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DriveBay2point5 = table.Column<byte>(type: "tinyint", nullable: true),
                    DriveBay3point5 = table.Column<byte>(type: "tinyint", nullable: true),
                    ExpansionSlots = table.Column<byte>(type: "tinyint", nullable: true),
                    FrontPorts = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FanOptions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RadioatorOptions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxGPULength = table.Column<short>(type: "smallint", nullable: true),
                    MaxCPUCoolerHeight = table.Column<byte>(type: "tinyint", nullable: true),
                    MaxPSULenght = table.Column<byte>(type: "tinyint", nullable: true),
                    Height = table.Column<float>(type: "real", nullable: true),
                    Width = table.Column<float>(type: "real", nullable: true),
                    Depth = table.Column<float>(type: "real", nullable: true),
                    Weight = table.Column<float>(type: "real", nullable: true),
                    Features = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<float>(type: "real", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrandId = table.Column<int>(type: "int", nullable: true),
                    SeriesId = table.Column<int>(type: "int", nullable: true),
                    Category = table.Column<int>(type: "int", nullable: false),
                    FirstAvailable = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cases_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cases_CaseTypes_CaseTypeId",
                        column: x => x.CaseTypeId,
                        principalTable: "CaseTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cases_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cases_Series_SeriesId",
                        column: x => x.SeriesId,
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CaseFormFactors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaseId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FormFactorId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseFormFactors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CaseFormFactors_Cases_CaseId",
                        column: x => x.CaseId,
                        principalTable: "Cases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CaseFormFactors_FormFactors_FormFactorId",
                        column: x => x.FormFactorId,
                        principalTable: "FormFactors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CaseMaterials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaseId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MaterialId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseMaterials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CaseMaterials_Cases_CaseId",
                        column: x => x.CaseId,
                        principalTable: "Cases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CaseMaterials_Materials_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CaseFormFactors_CaseId",
                table: "CaseFormFactors",
                column: "CaseId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseFormFactors_FormFactorId",
                table: "CaseFormFactors",
                column: "FormFactorId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseFormFactors_IsDeleted",
                table: "CaseFormFactors",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_CaseMaterials_CaseId",
                table: "CaseMaterials",
                column: "CaseId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseMaterials_IsDeleted",
                table: "CaseMaterials",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_CaseMaterials_MaterialId",
                table: "CaseMaterials",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Cases_BrandId",
                table: "Cases",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Cases_CaseTypeId",
                table: "Cases",
                column: "CaseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Cases_ColorId",
                table: "Cases",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Cases_IsDeleted",
                table: "Cases",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Cases_SeriesId",
                table: "Cases",
                column: "SeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseTypes_IsDeleted",
                table: "CaseTypes",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_IsDeleted",
                table: "Materials",
                column: "IsDeleted");

            migrationBuilder.AddForeignKey(
                name: "FK_CPUAirCoolers_Colors_ColorId",
                table: "CPUAirCoolers",
                column: "ColorId",
                principalTable: "Colors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CPUAirCoolers_Colors_ColorId",
                table: "CPUAirCoolers");

            migrationBuilder.DropTable(
                name: "CaseFormFactors");

            migrationBuilder.DropTable(
                name: "CaseMaterials");

            migrationBuilder.DropTable(
                name: "Cases");

            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropTable(
                name: "CaseTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Colors",
                table: "Colors");

            migrationBuilder.RenameTable(
                name: "Colors",
                newName: "Color");

            migrationBuilder.RenameIndex(
                name: "IX_Colors_IsDeleted",
                table: "Color",
                newName: "IX_Color_IsDeleted");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Color",
                table: "Color",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CPUAirCoolers_Color_ColorId",
                table: "CPUAirCoolers",
                column: "ColorId",
                principalTable: "Color",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
