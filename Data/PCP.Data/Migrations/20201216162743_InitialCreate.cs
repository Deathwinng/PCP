namespace PCP.Data.Migrations
{
    using System;

    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AudioChipsets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Channels = table.Column<float>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AudioChipsets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CoreNames",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoreNames", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FormFactors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormFactors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GPUInterfaces",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GPUInterfaces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IntegratedGraphics",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    BaseFrequency = table.Column<short>(nullable: true),
                    MaxFrequency = table.Column<short>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntegratedGraphics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LanChipsets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanChipsets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lithographies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lithographies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MemorySpeeds",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Speed = table.Column<short>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemorySpeeds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MemoryTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemoryTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MothrboardChipset",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MothrboardChipset", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ports",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Series",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Series", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sockets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sockets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
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
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
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
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
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
                name: "GPUCores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    BrandId = table.Column<int>(nullable: false),
                    SeriesId = table.Column<int>(nullable: true),
                    Cores = table.Column<short>(nullable: true)
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
                name: "CPUs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Price = table.Column<float>(nullable: true),
                    BrandId = table.Column<int>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    SeriesId = table.Column<int>(nullable: true),
                    SocketId = table.Column<int>(nullable: true),
                    CoreNameId = table.Column<int>(nullable: true),
                    Cores = table.Column<byte>(nullable: true),
                    Threads = table.Column<short>(nullable: true),
                    Frequency = table.Column<short>(nullable: true),
                    TurboFrequency = table.Column<short>(nullable: true),
                    L1Cache = table.Column<int>(nullable: true),
                    L2Cache = table.Column<int>(nullable: true),
                    L3Cache = table.Column<int>(nullable: true),
                    LithographyId = table.Column<int>(nullable: true),
                    SixtyFourBitSupport = table.Column<bool>(nullable: true),
                    MemoryChannel = table.Column<byte>(nullable: true),
                    MemoryTypeId = table.Column<int>(nullable: true),
                    MemorySpeedId = table.Column<int>(nullable: true),
                    VirtualizationSupport = table.Column<bool>(nullable: true),
                    IntegratedGraphicId = table.Column<int>(nullable: true),
                    PCIERevision = table.Column<float>(nullable: true),
                    PCIELanes = table.Column<byte>(nullable: true),
                    ThermalDesignPower = table.Column<short>(nullable: true),
                    HasCoolingDevice = table.Column<bool>(nullable: true),
                    FirstAvailable = table.Column<DateTime>(nullable: true)
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Price = table.Column<float>(nullable: true),
                    BrandId = table.Column<int>(nullable: false),
                    Model = table.Column<string>(nullable: true),
                    SeriesId = table.Column<int>(nullable: true),
                    SocketId = table.Column<int>(nullable: true),
                    ChipsetId = table.Column<int>(nullable: true),
                    MemorySlots = table.Column<int>(nullable: true),
                    MaxMemorySupport = table.Column<int>(nullable: true),
                    MemoryChannel = table.Column<byte>(nullable: true),
                    PCIex1 = table.Column<byte>(nullable: false),
                    PCIe3x16 = table.Column<byte>(nullable: false),
                    PCIe4x16 = table.Column<byte>(nullable: false),
                    Sata3Gbs = table.Column<byte>(nullable: false),
                    Sata6Gbs = table.Column<byte>(nullable: false),
                    Mdot2 = table.Column<byte>(nullable: false),
                    AudioChipsetId = table.Column<int>(nullable: true),
                    LanChipsetId = table.Column<int>(nullable: true),
                    RearPanelPorts = table.Column<string>(nullable: true),
                    FormFactorId = table.Column<int>(nullable: true),
                    Width = table.Column<float>(nullable: true),
                    Length = table.Column<float>(nullable: true),
                    Features = table.Column<string>(nullable: true),
                    FirstAvailable = table.Column<DateTime>(nullable: true)
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
                        name: "FK_Motherboards_MothrboardChipset_ChipsetId",
                        column: x => x.ChipsetId,
                        principalTable: "MothrboardChipset",
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
                name: "GPUChipsets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    GPUCoreId = table.Column<int>(nullable: true),
                    CoreClock = table.Column<short>(nullable: true),
                    TurboClock = table.Column<short>(nullable: true)
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    MotherboardId = table.Column<int>(nullable: false),
                    MemoryTypeId = table.Column<int>(nullable: false),
                    MemorySpeedId = table.Column<int>(nullable: true)
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Price = table.Column<float>(nullable: true),
                    BrandId = table.Column<int>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    SeriesId = table.Column<int>(nullable: true),
                    GPUInterfaceId = table.Column<int>(nullable: true),
                    GPUChipsetId = table.Column<int>(nullable: true),
                    MemoryTypeId = table.Column<int>(nullable: true),
                    MemorySize = table.Column<short>(nullable: true),
                    MemoryInterface = table.Column<short>(nullable: true),
                    MemoryBandwidth = table.Column<byte>(nullable: true),
                    DirectXVersion = table.Column<float>(nullable: true),
                    OpenGLVersion = table.Column<float>(nullable: true),
                    ThermalDesignPower = table.Column<short>(nullable: true),
                    Features = table.Column<string>(nullable: true),
                    Length = table.Column<float>(nullable: true),
                    Height = table.Column<float>(nullable: true),
                    SlotWidth = table.Column<float>(nullable: true),
                    FirstAvailable = table.Column<DateTime>(nullable: false)
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
                        name: "FK_GPUs_GPUInterfaces_GPUInterfaceId",
                        column: x => x.GPUInterfaceId,
                        principalTable: "GPUInterfaces",
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    GPUId = table.Column<int>(nullable: false),
                    PortId = table.Column<int>(nullable: false),
                    Quantity = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GPUPorts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GPUPorts_GPUs_GPUId",
                        column: x => x.GPUId,
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
                name: "IX_AspNetUsers_IsDeleted",
                table: "AspNetUsers",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

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
                name: "IX_CoreNames_IsDeleted",
                table: "CoreNames",
                column: "IsDeleted");

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
                name: "IX_GPUInterfaces_IsDeleted",
                table: "GPUInterfaces",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_GPUPorts_GPUId",
                table: "GPUPorts",
                column: "GPUId");

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
                name: "IX_IntegratedGraphics_IsDeleted",
                table: "IntegratedGraphics",
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
                name: "CPUs");

            migrationBuilder.DropTable(
                name: "GPUPorts");

            migrationBuilder.DropTable(
                name: "MotherboardMemoryTypes");

            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

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
                name: "GPUChipsets");

            migrationBuilder.DropTable(
                name: "GPUInterfaces");

            migrationBuilder.DropTable(
                name: "MemoryTypes");

            migrationBuilder.DropTable(
                name: "AudioChipsets");

            migrationBuilder.DropTable(
                name: "MothrboardChipset");

            migrationBuilder.DropTable(
                name: "FormFactors");

            migrationBuilder.DropTable(
                name: "LanChipsets");

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
