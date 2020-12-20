using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PCP.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AudioChipsets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Channels = table.Column<float>(type: "real", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AudioChipsets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
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
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Color",
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
                    table.PrimaryKey("PK_Color", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CoolerBearingTypes",
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
                    table.PrimaryKey("PK_CoolerBearingTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CoolerLEDTypes",
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
                    table.PrimaryKey("PK_CoolerLEDTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CoolerTypes",
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
                    table.PrimaryKey("PK_CoolerTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CoreNames",
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
                    table.PrimaryKey("PK_CoreNames", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FormFactors",
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
                    table.PrimaryKey("PK_FormFactors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IntegratedGraphics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BaseFrequency = table.Column<short>(type: "smallint", nullable: true),
                    MaxFrequency = table.Column<short>(type: "smallint", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntegratedGraphics", x => x.Id);
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
                name: "LanChipsets",
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
                    table.PrimaryKey("PK_LanChipsets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lithographies",
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
                    table.PrimaryKey("PK_Lithographies", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "MemorySpeeds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Speed = table.Column<short>(type: "smallint", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemorySpeeds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MemoryTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemoryTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MothrboardChipset",
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
                    table.PrimaryKey("PK_MothrboardChipset", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ports",
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
                    table.PrimaryKey("PK_Ports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Series",
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
                    table.PrimaryKey("PK_Series", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sockets",
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
                    table.PrimaryKey("PK_Sockets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usages",
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
                    table.PrimaryKey("PK_Usages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CPUAirCoolers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CoolerTypeId = table.Column<int>(type: "int", nullable: true),
                    FanSize = table.Column<short>(type: "smallint", nullable: true),
                    CoolerBearingTypeId = table.Column<int>(type: "int", nullable: true),
                    RPM = table.Column<short>(type: "smallint", nullable: true),
                    MaxAirFlow = table.Column<float>(type: "real", nullable: true),
                    MaxNoiseLevel = table.Column<float>(type: "real", nullable: true),
                    PowerConnectorPins = table.Column<byte>(type: "tinyint", nullable: true),
                    ColorId = table.Column<int>(type: "int", nullable: true),
                    CoolerLEDId = table.Column<int>(type: "int", nullable: true),
                    HeatsinkMaterial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxHeight = table.Column<byte>(type: "tinyint", nullable: true),
                    FanDimensions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeatsinkDimension = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_CPUAirCoolers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CPUAirCoolers_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CPUAirCoolers_Color_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Color",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CPUAirCoolers_CoolerBearingTypes_CoolerBearingTypeId",
                        column: x => x.CoolerBearingTypeId,
                        principalTable: "CoolerBearingTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CPUAirCoolers_CoolerLEDTypes_CoolerLEDId",
                        column: x => x.CoolerLEDId,
                        principalTable: "CoolerLEDTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CPUAirCoolers_CoolerTypes_CoolerTypeId",
                        column: x => x.CoolerTypeId,
                        principalTable: "CoolerTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CPUAirCoolers_Series_SeriesId",
                        column: x => x.SeriesId,
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GPUCores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    SeriesId = table.Column<int>(type: "int", nullable: true),
                    Cores = table.Column<short>(type: "smallint", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GPUCores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GPUCores_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GPUCores_Series_SeriesId",
                        column: x => x.SeriesId,
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Memories",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NumberOfModules = table.Column<byte>(type: "tinyint", nullable: true),
                    CapacityPerModule = table.Column<int>(type: "int", nullable: true),
                    MemoryTypeId = table.Column<int>(type: "int", nullable: true),
                    MemorySpeedId = table.Column<int>(type: "int", nullable: true),
                    ColumnAddressStrobeLatency = table.Column<float>(type: "real", nullable: true),
                    Timings = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Voltage = table.Column<float>(type: "real", nullable: true),
                    HeatSpreader = table.Column<bool>(type: "bit", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "CPUs",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SocketId = table.Column<int>(type: "int", nullable: true),
                    CoreNameId = table.Column<int>(type: "int", nullable: true),
                    Cores = table.Column<byte>(type: "tinyint", nullable: true),
                    Threads = table.Column<short>(type: "smallint", nullable: true),
                    Frequency = table.Column<short>(type: "smallint", nullable: true),
                    TurboFrequency = table.Column<short>(type: "smallint", nullable: true),
                    L1Cache = table.Column<int>(type: "int", nullable: true),
                    L2Cache = table.Column<int>(type: "int", nullable: true),
                    L3Cache = table.Column<int>(type: "int", nullable: true),
                    LithographyId = table.Column<int>(type: "int", nullable: true),
                    SixtyFourBitSupport = table.Column<bool>(type: "bit", nullable: true),
                    MemoryChannel = table.Column<byte>(type: "tinyint", nullable: true),
                    MemoryTypeId = table.Column<int>(type: "int", nullable: true),
                    MemorySpeedId = table.Column<int>(type: "int", nullable: true),
                    VirtualizationSupport = table.Column<bool>(type: "bit", nullable: true),
                    IntegratedGraphicId = table.Column<int>(type: "int", nullable: true),
                    PCIERevision = table.Column<float>(type: "real", nullable: true),
                    PCIELanes = table.Column<byte>(type: "tinyint", nullable: true),
                    ThermalDesignPower = table.Column<short>(type: "smallint", nullable: true),
                    HasCoolingDevice = table.Column<bool>(type: "bit", nullable: true),
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
                    table.PrimaryKey("PK_CPUs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CPUs_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CPUs_CoreNames_CoreNameId",
                        column: x => x.CoreNameId,
                        principalTable: "CoreNames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CPUs_IntegratedGraphics_IntegratedGraphicId",
                        column: x => x.IntegratedGraphicId,
                        principalTable: "IntegratedGraphics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CPUs_Lithographies_LithographyId",
                        column: x => x.LithographyId,
                        principalTable: "Lithographies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CPUs_MemorySpeeds_MemorySpeedId",
                        column: x => x.MemorySpeedId,
                        principalTable: "MemorySpeeds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CPUs_MemoryTypes_MemoryTypeId",
                        column: x => x.MemoryTypeId,
                        principalTable: "MemoryTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CPUs_Series_SeriesId",
                        column: x => x.SeriesId,
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CPUs_Sockets_SocketId",
                        column: x => x.SocketId,
                        principalTable: "Sockets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Motherboards",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SocketId = table.Column<int>(type: "int", nullable: true),
                    ChipsetId = table.Column<int>(type: "int", nullable: true),
                    MemorySlots = table.Column<int>(type: "int", nullable: true),
                    MaxMemorySupport = table.Column<int>(type: "int", nullable: true),
                    MemoryChannel = table.Column<byte>(type: "tinyint", nullable: true),
                    PCIex1 = table.Column<byte>(type: "tinyint", nullable: false),
                    PCIe3x16 = table.Column<byte>(type: "tinyint", nullable: false),
                    PCIe4x16 = table.Column<byte>(type: "tinyint", nullable: false),
                    Sata3Gbs = table.Column<byte>(type: "tinyint", nullable: false),
                    Sata6Gbs = table.Column<byte>(type: "tinyint", nullable: false),
                    Mdot2 = table.Column<byte>(type: "tinyint", nullable: false),
                    AudioChipsetId = table.Column<int>(type: "int", nullable: true),
                    LanChipsetId = table.Column<int>(type: "int", nullable: true),
                    RearPanelPorts = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FormFactorId = table.Column<int>(type: "int", nullable: true),
                    Width = table.Column<float>(type: "real", nullable: true),
                    Length = table.Column<float>(type: "real", nullable: true),
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
                    table.PrimaryKey("PK_Motherboards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Motherboards_AudioChipsets_AudioChipsetId",
                        column: x => x.AudioChipsetId,
                        principalTable: "AudioChipsets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Motherboards_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Motherboards_FormFactors_FormFactorId",
                        column: x => x.FormFactorId,
                        principalTable: "FormFactors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Motherboards_LanChipsets_LanChipsetId",
                        column: x => x.LanChipsetId,
                        principalTable: "LanChipsets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Motherboards_MothrboardChipset_ChipsetId",
                        column: x => x.ChipsetId,
                        principalTable: "MothrboardChipset",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Motherboards_Series_SeriesId",
                        column: x => x.SeriesId,
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Motherboards_Sockets_SocketId",
                        column: x => x.SocketId,
                        principalTable: "Sockets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HDDs",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RevolutionsPerMinute = table.Column<short>(type: "smallint", nullable: true),
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
                    FirstAvailable = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InterfaceId = table.Column<int>(type: "int", nullable: true),
                    CapacityGb = table.Column<short>(type: "smallint", nullable: true),
                    CacheKb = table.Column<int>(type: "int", nullable: true),
                    Features = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsageId = table.Column<int>(type: "int", nullable: true),
                    FormFactorId = table.Column<int>(type: "int", nullable: true),
                    Height = table.Column<float>(type: "real", nullable: true),
                    Width = table.Column<float>(type: "real", nullable: true),
                    Length = table.Column<float>(type: "real", nullable: true)
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
                    table.ForeignKey(
                        name: "FK_HDDs_Usages_UsageId",
                        column: x => x.UsageId,
                        principalTable: "Usages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SSDs",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MemoryComponentId = table.Column<int>(type: "int", nullable: true),
                    MaxSequentialReadMBps = table.Column<short>(type: "smallint", nullable: true),
                    MaxSequentialWriteMBps = table.Column<short>(type: "smallint", nullable: true),
                    FourKBRandomRead = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FourKBRandomWrite = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MeanTimeBetweenFailures = table.Column<int>(type: "int", nullable: true),
                    IdlePowerComsumtion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActivePowerConsumption = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    FirstAvailable = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InterfaceId = table.Column<int>(type: "int", nullable: true),
                    CapacityGb = table.Column<short>(type: "smallint", nullable: true),
                    CacheKb = table.Column<int>(type: "int", nullable: true),
                    Features = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsageId = table.Column<int>(type: "int", nullable: true),
                    FormFactorId = table.Column<int>(type: "int", nullable: true),
                    Height = table.Column<float>(type: "real", nullable: true),
                    Width = table.Column<float>(type: "real", nullable: true),
                    Length = table.Column<float>(type: "real", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SSDs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SSDs_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SSDs_FormFactors_FormFactorId",
                        column: x => x.FormFactorId,
                        principalTable: "FormFactors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SSDs_Interfaces_InterfaceId",
                        column: x => x.InterfaceId,
                        principalTable: "Interfaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SSDs_MemoryComponents_MemoryComponentId",
                        column: x => x.MemoryComponentId,
                        principalTable: "MemoryComponents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SSDs_Series_SeriesId",
                        column: x => x.SeriesId,
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SSDs_Usages_UsageId",
                        column: x => x.UsageId,
                        principalTable: "Usages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CPUAirCoolerSockets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CPUAirCoolerId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SocketId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CPUAirCoolerSockets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CPUAirCoolerSockets_CPUAirCoolers_CPUAirCoolerId",
                        column: x => x.CPUAirCoolerId,
                        principalTable: "CPUAirCoolers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CPUAirCoolerSockets_Sockets_SocketId",
                        column: x => x.SocketId,
                        principalTable: "Sockets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GPUChipsets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GPUCoreId = table.Column<int>(type: "int", nullable: true),
                    CoreClock = table.Column<short>(type: "smallint", nullable: true),
                    TurboClock = table.Column<short>(type: "smallint", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GPUChipsets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GPUChipsets_GPUCores_GPUCoreId",
                        column: x => x.GPUCoreId,
                        principalTable: "GPUCores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MotherboardMemoryTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MotherboardId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MemoryTypeId = table.Column<int>(type: "int", nullable: false),
                    MemorySpeedId = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotherboardMemoryTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MotherboardMemoryTypes_MemorySpeeds_MemorySpeedId",
                        column: x => x.MemorySpeedId,
                        principalTable: "MemorySpeeds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MotherboardMemoryTypes_MemoryTypes_MemoryTypeId",
                        column: x => x.MemoryTypeId,
                        principalTable: "MemoryTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MotherboardMemoryTypes_Motherboards_MotherboardId",
                        column: x => x.MotherboardId,
                        principalTable: "Motherboards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GPUs",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GPUInterfaceId = table.Column<int>(type: "int", nullable: true),
                    GPUChipsetId = table.Column<int>(type: "int", nullable: true),
                    MemoryTypeId = table.Column<int>(type: "int", nullable: true),
                    MemorySize = table.Column<int>(type: "int", nullable: true),
                    MemoryInterface = table.Column<short>(type: "smallint", nullable: true),
                    MemoryBandwidth = table.Column<byte>(type: "tinyint", nullable: true),
                    DirectXVersion = table.Column<float>(type: "real", nullable: true),
                    OpenGLVersion = table.Column<float>(type: "real", nullable: true),
                    ThermalDesignPower = table.Column<short>(type: "smallint", nullable: true),
                    Features = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Length = table.Column<float>(type: "real", nullable: true),
                    Height = table.Column<float>(type: "real", nullable: true),
                    SlotWidth = table.Column<float>(type: "real", nullable: true),
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
                    table.PrimaryKey("PK_GPUs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GPUs_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GPUs_GPUChipsets_GPUChipsetId",
                        column: x => x.GPUChipsetId,
                        principalTable: "GPUChipsets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GPUs_Interfaces_GPUInterfaceId",
                        column: x => x.GPUInterfaceId,
                        principalTable: "Interfaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GPUs_MemoryTypes_MemoryTypeId",
                        column: x => x.MemoryTypeId,
                        principalTable: "MemoryTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GPUs_Series_SeriesId",
                        column: x => x.SeriesId,
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GPUPorts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GPUId = table.Column<int>(type: "int", nullable: false),
                    GPUId1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PortId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<byte>(type: "tinyint", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GPUPorts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GPUPorts_GPUs_GPUId1",
                        column: x => x.GPUId1,
                        principalTable: "GPUs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GPUPorts_Ports_PortId",
                        column: x => x.PortId,
                        principalTable: "Ports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoles_IsDeleted",
                table: "AspNetRoles",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_IsDeleted",
                table: "AspNetUsers",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AudioChipsets_IsDeleted",
                table: "AudioChipsets",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Brands_IsDeleted",
                table: "Brands",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Color_IsDeleted",
                table: "Color",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_CoolerBearingTypes_IsDeleted",
                table: "CoolerBearingTypes",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_CoolerLEDTypes_IsDeleted",
                table: "CoolerLEDTypes",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_CoolerTypes_IsDeleted",
                table: "CoolerTypes",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_CoreNames_IsDeleted",
                table: "CoreNames",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_CPUAirCoolers_BrandId",
                table: "CPUAirCoolers",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_CPUAirCoolers_ColorId",
                table: "CPUAirCoolers",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_CPUAirCoolers_CoolerBearingTypeId",
                table: "CPUAirCoolers",
                column: "CoolerBearingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CPUAirCoolers_CoolerLEDId",
                table: "CPUAirCoolers",
                column: "CoolerLEDId");

            migrationBuilder.CreateIndex(
                name: "IX_CPUAirCoolers_CoolerTypeId",
                table: "CPUAirCoolers",
                column: "CoolerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CPUAirCoolers_IsDeleted",
                table: "CPUAirCoolers",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_CPUAirCoolers_SeriesId",
                table: "CPUAirCoolers",
                column: "SeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_CPUAirCoolerSockets_CPUAirCoolerId",
                table: "CPUAirCoolerSockets",
                column: "CPUAirCoolerId");

            migrationBuilder.CreateIndex(
                name: "IX_CPUAirCoolerSockets_IsDeleted",
                table: "CPUAirCoolerSockets",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_CPUAirCoolerSockets_SocketId",
                table: "CPUAirCoolerSockets",
                column: "SocketId");

            migrationBuilder.CreateIndex(
                name: "IX_CPUs_BrandId",
                table: "CPUs",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_CPUs_CoreNameId",
                table: "CPUs",
                column: "CoreNameId");

            migrationBuilder.CreateIndex(
                name: "IX_CPUs_IntegratedGraphicId",
                table: "CPUs",
                column: "IntegratedGraphicId");

            migrationBuilder.CreateIndex(
                name: "IX_CPUs_IsDeleted",
                table: "CPUs",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_CPUs_LithographyId",
                table: "CPUs",
                column: "LithographyId");

            migrationBuilder.CreateIndex(
                name: "IX_CPUs_MemorySpeedId",
                table: "CPUs",
                column: "MemorySpeedId");

            migrationBuilder.CreateIndex(
                name: "IX_CPUs_MemoryTypeId",
                table: "CPUs",
                column: "MemoryTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CPUs_SeriesId",
                table: "CPUs",
                column: "SeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_CPUs_SocketId",
                table: "CPUs",
                column: "SocketId");

            migrationBuilder.CreateIndex(
                name: "IX_FormFactors_IsDeleted",
                table: "FormFactors",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_GPUChipsets_GPUCoreId",
                table: "GPUChipsets",
                column: "GPUCoreId");

            migrationBuilder.CreateIndex(
                name: "IX_GPUChipsets_IsDeleted",
                table: "GPUChipsets",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_GPUCores_BrandId",
                table: "GPUCores",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_GPUCores_IsDeleted",
                table: "GPUCores",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_GPUCores_SeriesId",
                table: "GPUCores",
                column: "SeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_GPUPorts_GPUId1",
                table: "GPUPorts",
                column: "GPUId1");

            migrationBuilder.CreateIndex(
                name: "IX_GPUPorts_IsDeleted",
                table: "GPUPorts",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_GPUPorts_PortId",
                table: "GPUPorts",
                column: "PortId");

            migrationBuilder.CreateIndex(
                name: "IX_GPUs_BrandId",
                table: "GPUs",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_GPUs_GPUChipsetId",
                table: "GPUs",
                column: "GPUChipsetId");

            migrationBuilder.CreateIndex(
                name: "IX_GPUs_GPUInterfaceId",
                table: "GPUs",
                column: "GPUInterfaceId");

            migrationBuilder.CreateIndex(
                name: "IX_GPUs_IsDeleted",
                table: "GPUs",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_GPUs_MemoryTypeId",
                table: "GPUs",
                column: "MemoryTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_GPUs_SeriesId",
                table: "GPUs",
                column: "SeriesId");

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
                name: "IX_IntegratedGraphics_IsDeleted",
                table: "IntegratedGraphics",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Interfaces_IsDeleted",
                table: "Interfaces",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_LanChipsets_IsDeleted",
                table: "LanChipsets",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Lithographies_IsDeleted",
                table: "Lithographies",
                column: "IsDeleted");

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

            migrationBuilder.CreateIndex(
                name: "IX_MemoryComponents_IsDeleted",
                table: "MemoryComponents",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_MemorySpeeds_IsDeleted",
                table: "MemorySpeeds",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_MemoryTypes_IsDeleted",
                table: "MemoryTypes",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_MotherboardMemoryTypes_IsDeleted",
                table: "MotherboardMemoryTypes",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_MotherboardMemoryTypes_MemorySpeedId",
                table: "MotherboardMemoryTypes",
                column: "MemorySpeedId");

            migrationBuilder.CreateIndex(
                name: "IX_MotherboardMemoryTypes_MemoryTypeId",
                table: "MotherboardMemoryTypes",
                column: "MemoryTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MotherboardMemoryTypes_MotherboardId",
                table: "MotherboardMemoryTypes",
                column: "MotherboardId");

            migrationBuilder.CreateIndex(
                name: "IX_Motherboards_AudioChipsetId",
                table: "Motherboards",
                column: "AudioChipsetId");

            migrationBuilder.CreateIndex(
                name: "IX_Motherboards_BrandId",
                table: "Motherboards",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Motherboards_ChipsetId",
                table: "Motherboards",
                column: "ChipsetId");

            migrationBuilder.CreateIndex(
                name: "IX_Motherboards_FormFactorId",
                table: "Motherboards",
                column: "FormFactorId");

            migrationBuilder.CreateIndex(
                name: "IX_Motherboards_IsDeleted",
                table: "Motherboards",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Motherboards_LanChipsetId",
                table: "Motherboards",
                column: "LanChipsetId");

            migrationBuilder.CreateIndex(
                name: "IX_Motherboards_SeriesId",
                table: "Motherboards",
                column: "SeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_Motherboards_SocketId",
                table: "Motherboards",
                column: "SocketId");

            migrationBuilder.CreateIndex(
                name: "IX_MothrboardChipset_IsDeleted",
                table: "MothrboardChipset",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Ports_IsDeleted",
                table: "Ports",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Series_IsDeleted",
                table: "Series",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Settings_IsDeleted",
                table: "Settings",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Sockets_IsDeleted",
                table: "Sockets",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_SSDs_BrandId",
                table: "SSDs",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_SSDs_FormFactorId",
                table: "SSDs",
                column: "FormFactorId");

            migrationBuilder.CreateIndex(
                name: "IX_SSDs_InterfaceId",
                table: "SSDs",
                column: "InterfaceId");

            migrationBuilder.CreateIndex(
                name: "IX_SSDs_IsDeleted",
                table: "SSDs",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_SSDs_MemoryComponentId",
                table: "SSDs",
                column: "MemoryComponentId");

            migrationBuilder.CreateIndex(
                name: "IX_SSDs_SeriesId",
                table: "SSDs",
                column: "SeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_SSDs_UsageId",
                table: "SSDs",
                column: "UsageId");

            migrationBuilder.CreateIndex(
                name: "IX_Usages_IsDeleted",
                table: "Usages",
                column: "IsDeleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CPUAirCoolerSockets");

            migrationBuilder.DropTable(
                name: "CPUs");

            migrationBuilder.DropTable(
                name: "GPUPorts");

            migrationBuilder.DropTable(
                name: "HDDs");

            migrationBuilder.DropTable(
                name: "Memories");

            migrationBuilder.DropTable(
                name: "MotherboardMemoryTypes");

            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropTable(
                name: "SSDs");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "CPUAirCoolers");

            migrationBuilder.DropTable(
                name: "CoreNames");

            migrationBuilder.DropTable(
                name: "IntegratedGraphics");

            migrationBuilder.DropTable(
                name: "Lithographies");

            migrationBuilder.DropTable(
                name: "GPUs");

            migrationBuilder.DropTable(
                name: "Ports");

            migrationBuilder.DropTable(
                name: "MemorySpeeds");

            migrationBuilder.DropTable(
                name: "Motherboards");

            migrationBuilder.DropTable(
                name: "MemoryComponents");

            migrationBuilder.DropTable(
                name: "Usages");

            migrationBuilder.DropTable(
                name: "Color");

            migrationBuilder.DropTable(
                name: "CoolerBearingTypes");

            migrationBuilder.DropTable(
                name: "CoolerLEDTypes");

            migrationBuilder.DropTable(
                name: "CoolerTypes");

            migrationBuilder.DropTable(
                name: "GPUChipsets");

            migrationBuilder.DropTable(
                name: "Interfaces");

            migrationBuilder.DropTable(
                name: "MemoryTypes");

            migrationBuilder.DropTable(
                name: "AudioChipsets");

            migrationBuilder.DropTable(
                name: "FormFactors");

            migrationBuilder.DropTable(
                name: "LanChipsets");

            migrationBuilder.DropTable(
                name: "MothrboardChipset");

            migrationBuilder.DropTable(
                name: "Sockets");

            migrationBuilder.DropTable(
                name: "GPUCores");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Series");
        }
    }
}
