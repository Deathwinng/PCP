using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PCP.Data.Migrations
{
    public partial class AddMemoryComponentsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ActivePowerConsumption",
                table: "SSDs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FourKBRandomRead",
                table: "SSDs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FourKBRandomWrite",
                table: "SSDs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdlePowerComsumtion",
                table: "SSDs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "MaxSequentialReadMBps",
                table: "SSDs",
                type: "smallint",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "MaxSequentialWriteMBps",
                table: "SSDs",
                type: "smallint",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MeanTimeBetweenFailures",
                table: "SSDs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MemoryComponentId",
                table: "SSDs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MemoryComponents",
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
                    table.PrimaryKey("PK_MemoryComponents", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SSDs_MemoryComponentId",
                table: "SSDs",
                column: "MemoryComponentId");

            migrationBuilder.CreateIndex(
                name: "IX_MemoryComponents_IsDeleted",
                table: "MemoryComponents",
                column: "IsDeleted");

            migrationBuilder.AddForeignKey(
                name: "FK_SSDs_MemoryComponents_MemoryComponentId",
                table: "SSDs",
                column: "MemoryComponentId",
                principalTable: "MemoryComponents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SSDs_MemoryComponents_MemoryComponentId",
                table: "SSDs");

            migrationBuilder.DropTable(
                name: "MemoryComponents");

            migrationBuilder.DropIndex(
                name: "IX_SSDs_MemoryComponentId",
                table: "SSDs");

            migrationBuilder.DropColumn(
                name: "ActivePowerConsumption",
                table: "SSDs");

            migrationBuilder.DropColumn(
                name: "FourKBRandomRead",
                table: "SSDs");

            migrationBuilder.DropColumn(
                name: "FourKBRandomWrite",
                table: "SSDs");

            migrationBuilder.DropColumn(
                name: "IdlePowerComsumtion",
                table: "SSDs");

            migrationBuilder.DropColumn(
                name: "MaxSequentialReadMBps",
                table: "SSDs");

            migrationBuilder.DropColumn(
                name: "MaxSequentialWriteMBps",
                table: "SSDs");

            migrationBuilder.DropColumn(
                name: "MeanTimeBetweenFailures",
                table: "SSDs");

            migrationBuilder.DropColumn(
                name: "MemoryComponentId",
                table: "SSDs");
        }
    }
}
