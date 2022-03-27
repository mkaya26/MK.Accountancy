using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MK.Accountancy.Migrations
{
    public partial class AllEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppDepartments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "VarChar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "VarChar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "VarChar(250)", maxLength: 250, nullable: true),
                    Active = table.Column<bool>(type: "Bit", nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppDepartments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppSpecialCodes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "VarChar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "VarChar(50)", maxLength: 50, nullable: false),
                    SpecialCodeType = table.Column<byte>(type: "TinyInt", nullable: false),
                    CardType = table.Column<byte>(type: "TinyInt", nullable: false),
                    Description = table.Column<string>(type: "VarChar(250)", maxLength: 250, nullable: true),
                    Active = table.Column<bool>(type: "Bit", nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppSpecialCodes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppTerms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "VarChar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "VarChar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "VarChar(250)", maxLength: 250, nullable: true),
                    Active = table.Column<bool>(type: "Bit", nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppTerms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppBanks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "VarChar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "VarChar(50)", maxLength: 50, nullable: false),
                    SpecialCodeOneId = table.Column<Guid>(type: "UniqueIdentifier", nullable: true),
                    SpecialCodeTwoId = table.Column<Guid>(type: "UniqueIdentifier", nullable: true),
                    Description = table.Column<string>(type: "VarChar(250)", maxLength: 250, nullable: true),
                    Active = table.Column<bool>(type: "Bit", nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppBanks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppBanks_AppSpecialCodes_SpecialCodeOneId",
                        column: x => x.SpecialCodeOneId,
                        principalTable: "AppSpecialCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppBanks_AppSpecialCodes_SpecialCodeTwoId",
                        column: x => x.SpecialCodeTwoId,
                        principalTable: "AppSpecialCodes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AppCurrents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "VarChar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "VarChar(50)", maxLength: 50, nullable: false),
                    TaxDepartment = table.Column<string>(type: "VarChar(50)", maxLength: 50, nullable: true),
                    TaxNumber = table.Column<string>(type: "VarChar(50)", maxLength: 50, nullable: true),
                    Telephone = table.Column<string>(type: "VarChar(15)", maxLength: 15, nullable: true),
                    Address = table.Column<string>(type: "VarChar(250)", maxLength: 250, nullable: true),
                    SpecialCodeOneId = table.Column<Guid>(type: "UniqueIdentifier", nullable: true),
                    SpecialCodeTwoId = table.Column<Guid>(type: "UniqueIdentifier", nullable: true),
                    Description = table.Column<string>(type: "VarChar(250)", maxLength: 250, nullable: true),
                    Active = table.Column<bool>(type: "Bit", nullable: false),
                    CurrentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppCurrents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppCurrents_AppCurrents_CurrentId",
                        column: x => x.CurrentId,
                        principalTable: "AppCurrents",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppCurrents_AppSpecialCodes_SpecialCodeOneId",
                        column: x => x.SpecialCodeOneId,
                        principalTable: "AppSpecialCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppCurrents_AppSpecialCodes_SpecialCodeTwoId",
                        column: x => x.SpecialCodeTwoId,
                        principalTable: "AppSpecialCodes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AppSafes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "VarChar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "VarChar(50)", maxLength: 50, nullable: false),
                    SpecialCodeOneId = table.Column<Guid>(type: "UniqueIdentifier", nullable: true),
                    SpecialCodeTwoId = table.Column<Guid>(type: "UniqueIdentifier", nullable: true),
                    DepartmentId = table.Column<Guid>(type: "UniqueIdentifier", nullable: false),
                    Description = table.Column<string>(type: "VarChar(250)", maxLength: 250, nullable: true),
                    Active = table.Column<bool>(type: "Bit", nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppSafes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppSafes_AppDepartments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "AppDepartments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppSafes_AppSpecialCodes_SpecialCodeOneId",
                        column: x => x.SpecialCodeOneId,
                        principalTable: "AppSpecialCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppSafes_AppSpecialCodes_SpecialCodeTwoId",
                        column: x => x.SpecialCodeTwoId,
                        principalTable: "AppSpecialCodes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AppStores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "VarChar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "VarChar(50)", maxLength: 50, nullable: false),
                    DepartmentId = table.Column<Guid>(type: "UniqueIdentifier", nullable: false),
                    SpecialCodeOneId = table.Column<Guid>(type: "UniqueIdentifier", nullable: true),
                    SpecialCodeTwoId = table.Column<Guid>(type: "UniqueIdentifier", nullable: true),
                    Description = table.Column<string>(type: "VarChar(250)", maxLength: 250, nullable: true),
                    Active = table.Column<bool>(type: "Bit", nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppStores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppStores_AppDepartments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "AppDepartments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppStores_AppSpecialCodes_SpecialCodeOneId",
                        column: x => x.SpecialCodeOneId,
                        principalTable: "AppSpecialCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppStores_AppSpecialCodes_SpecialCodeTwoId",
                        column: x => x.SpecialCodeTwoId,
                        principalTable: "AppSpecialCodes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AppUnits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "VarChar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "VarChar(50)", maxLength: 50, nullable: false),
                    SpecialCodeOneId = table.Column<Guid>(type: "UniqueIdentifier", nullable: true),
                    SpecialCodeTwoId = table.Column<Guid>(type: "UniqueIdentifier", nullable: true),
                    Description = table.Column<string>(type: "VarChar(250)", maxLength: 250, nullable: true),
                    Active = table.Column<bool>(type: "Bit", nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUnits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUnits_AppSpecialCodes_SpecialCodeOneId",
                        column: x => x.SpecialCodeOneId,
                        principalTable: "AppSpecialCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppUnits_AppSpecialCodes_SpecialCodeTwoId",
                        column: x => x.SpecialCodeTwoId,
                        principalTable: "AppSpecialCodes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AppBankDepartments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "VarChar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "VarChar(50)", maxLength: 50, nullable: false),
                    BankId = table.Column<Guid>(type: "UniqueIdentifier", nullable: false),
                    SpecialCodeOneId = table.Column<Guid>(type: "UniqueIdentifier", nullable: true),
                    SpecialCodeTwoId = table.Column<Guid>(type: "UniqueIdentifier", nullable: true),
                    Description = table.Column<string>(type: "VarChar(250)", maxLength: 250, nullable: true),
                    Active = table.Column<bool>(type: "Bit", nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppBankDepartments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppBankDepartments_AppBanks_BankId",
                        column: x => x.BankId,
                        principalTable: "AppBanks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppBankDepartments_AppSpecialCodes_SpecialCodeOneId",
                        column: x => x.SpecialCodeOneId,
                        principalTable: "AppSpecialCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppBankDepartments_AppSpecialCodes_SpecialCodeTwoId",
                        column: x => x.SpecialCodeTwoId,
                        principalTable: "AppSpecialCodes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AppInvoices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InvoiceType = table.Column<byte>(type: "TinyInt", nullable: false),
                    InvoiceNumber = table.Column<string>(type: "VarChar(16)", maxLength: 16, nullable: false),
                    InvoiceDate = table.Column<DateTime>(type: "Date", nullable: false),
                    GrandTotal = table.Column<decimal>(type: "Money", nullable: false),
                    DiscountTotal = table.Column<decimal>(type: "Money", nullable: false),
                    SubTotal = table.Column<decimal>(type: "Money", nullable: false),
                    TaxAmount = table.Column<decimal>(type: "Money", nullable: false),
                    Netamount = table.Column<decimal>(type: "Money", nullable: false),
                    MovementNumber = table.Column<int>(type: "Int", nullable: false),
                    CurrentId = table.Column<Guid>(type: "UniqueIdentifier", nullable: false),
                    SpecialCodeOneId = table.Column<Guid>(type: "UniqueIdentifier", nullable: true),
                    SpecialCodeTwoId = table.Column<Guid>(type: "UniqueIdentifier", nullable: true),
                    DepartmentId = table.Column<Guid>(type: "UniqueIdentifier", nullable: false),
                    TermId = table.Column<Guid>(type: "UniqueIdentifier", nullable: false),
                    Description = table.Column<string>(type: "VarChar(250)", maxLength: 250, nullable: true),
                    Active = table.Column<bool>(type: "Bit", nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppInvoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppInvoices_AppCurrents_CurrentId",
                        column: x => x.CurrentId,
                        principalTable: "AppCurrents",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppInvoices_AppDepartments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "AppDepartments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppInvoices_AppSpecialCodes_SpecialCodeOneId",
                        column: x => x.SpecialCodeOneId,
                        principalTable: "AppSpecialCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppInvoices_AppSpecialCodes_SpecialCodeTwoId",
                        column: x => x.SpecialCodeTwoId,
                        principalTable: "AppSpecialCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppInvoices_AppTerms_TermId",
                        column: x => x.TermId,
                        principalTable: "AppTerms",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AppOrganizationParameters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "UniqueIdentifier", nullable: false),
                    DepartmentId = table.Column<Guid>(type: "UniqueIdentifier", nullable: false),
                    TermId = table.Column<Guid>(type: "UniqueIdentifier", nullable: false),
                    StoryId = table.Column<Guid>(type: "UniqueIdentifier", nullable: true),
                    StoreId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppOrganizationParameters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppOrganizationParameters_AbpUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppOrganizationParameters_AppDepartments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "AppDepartments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppOrganizationParameters_AppStores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "AppStores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppOrganizationParameters_AppTerms_TermId",
                        column: x => x.TermId,
                        principalTable: "AppTerms",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AppExpenses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "VarChar(20)", maxLength: 20, nullable: false),
                    Barcode = table.Column<string>(type: "VarChar(250)", maxLength: 250, nullable: true),
                    Name = table.Column<string>(type: "VarChar(50)", maxLength: 50, nullable: false),
                    TaxRate = table.Column<int>(type: "Int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "Money", nullable: false),
                    UnitId = table.Column<Guid>(type: "UniqueIdentifier", nullable: false),
                    SpecialCodeOneId = table.Column<Guid>(type: "UniqueIdentifier", nullable: true),
                    SpecialCodeTwoId = table.Column<Guid>(type: "UniqueIdentifier", nullable: true),
                    Description = table.Column<string>(type: "VarChar(250)", maxLength: 250, nullable: true),
                    Active = table.Column<bool>(type: "Bit", nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppExpenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppExpenses_AppSpecialCodes_SpecialCodeOneId",
                        column: x => x.SpecialCodeOneId,
                        principalTable: "AppSpecialCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppExpenses_AppSpecialCodes_SpecialCodeTwoId",
                        column: x => x.SpecialCodeTwoId,
                        principalTable: "AppSpecialCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppExpenses_AppUnits_UnitId",
                        column: x => x.UnitId,
                        principalTable: "AppUnits",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AppServices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "VarChar(20)", maxLength: 20, nullable: false),
                    Barcode = table.Column<string>(type: "VarChar(250)", maxLength: 250, nullable: true),
                    Name = table.Column<string>(type: "VarChar(50)", maxLength: 50, nullable: false),
                    TaxRate = table.Column<int>(type: "Int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "Money", nullable: false),
                    UnitId = table.Column<Guid>(type: "UniqueIdentifier", nullable: false),
                    SpecialCodeOneId = table.Column<Guid>(type: "UniqueIdentifier", nullable: true),
                    SpecialCodeTwoId = table.Column<Guid>(type: "UniqueIdentifier", nullable: true),
                    Description = table.Column<string>(type: "VarChar(250)", maxLength: 250, nullable: true),
                    Active = table.Column<bool>(type: "Bit", nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppServices_AppSpecialCodes_SpecialCodeOneId",
                        column: x => x.SpecialCodeOneId,
                        principalTable: "AppSpecialCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppServices_AppSpecialCodes_SpecialCodeTwoId",
                        column: x => x.SpecialCodeTwoId,
                        principalTable: "AppSpecialCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppServices_AppUnits_UnitId",
                        column: x => x.UnitId,
                        principalTable: "AppUnits",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AppStocks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "VarChar(20)", maxLength: 20, nullable: false),
                    Barcode = table.Column<string>(type: "VarChar(250)", maxLength: 250, nullable: true),
                    Name = table.Column<string>(type: "VarChar(50)", maxLength: 50, nullable: false),
                    TaxRate = table.Column<int>(type: "Int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "Money", nullable: false),
                    UnitId = table.Column<Guid>(type: "UniqueIdentifier", nullable: false),
                    SpecialCodeOneId = table.Column<Guid>(type: "UniqueIdentifier", nullable: true),
                    SpecialCodeTwoId = table.Column<Guid>(type: "UniqueIdentifier", nullable: true),
                    Description = table.Column<string>(type: "VarChar(250)", maxLength: 250, nullable: true),
                    Active = table.Column<bool>(type: "Bit", nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppStocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppStocks_AppSpecialCodes_SpecialCodeOneId",
                        column: x => x.SpecialCodeOneId,
                        principalTable: "AppSpecialCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppStocks_AppSpecialCodes_SpecialCodeTwoId",
                        column: x => x.SpecialCodeTwoId,
                        principalTable: "AppSpecialCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppStocks_AppUnits_UnitId",
                        column: x => x.UnitId,
                        principalTable: "AppUnits",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AppBankAccounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "VarChar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "VarChar(50)", maxLength: 50, nullable: false),
                    BankAccountType = table.Column<byte>(type: "TinyInt", nullable: false),
                    AccountId = table.Column<string>(type: "VarChar(20)", maxLength: 20, nullable: false),
                    Iban = table.Column<string>(type: "VarChar(26)", maxLength: 26, nullable: true),
                    BankDepartmentId = table.Column<Guid>(type: "UniqueIdentifier", nullable: false),
                    SpecialCodeOneId = table.Column<Guid>(type: "UniqueIdentifier", nullable: true),
                    SpecialCodeTwoId = table.Column<Guid>(type: "UniqueIdentifier", nullable: true),
                    DepartmentId = table.Column<Guid>(type: "UniqueIdentifier", nullable: false),
                    Description = table.Column<string>(type: "VarChar(250)", maxLength: 250, nullable: true),
                    Active = table.Column<bool>(type: "Bit", nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppBankAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppBankAccounts_AppBankDepartments_BankDepartmentId",
                        column: x => x.BankDepartmentId,
                        principalTable: "AppBankDepartments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppBankAccounts_AppDepartments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "AppDepartments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppBankAccounts_AppSpecialCodes_SpecialCodeOneId",
                        column: x => x.SpecialCodeOneId,
                        principalTable: "AppSpecialCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppBankAccounts_AppSpecialCodes_SpecialCodeTwoId",
                        column: x => x.SpecialCodeTwoId,
                        principalTable: "AppSpecialCodes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AppInvoiceDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InvoiceId = table.Column<Guid>(type: "UniqueIdentifier", nullable: false),
                    InvoiceDetailType = table.Column<byte>(type: "TinyInt", nullable: false),
                    StockId = table.Column<Guid>(type: "UniqueIdentifier", nullable: true),
                    ServiceId = table.Column<Guid>(type: "UniqueIdentifier", nullable: true),
                    ExpenseId = table.Column<Guid>(type: "UniqueIdentifier", nullable: true),
                    StoryId = table.Column<Guid>(type: "UniqueIdentifier", nullable: true),
                    Quantity = table.Column<decimal>(type: "Decimal", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "Money", nullable: false),
                    GrossAmount = table.Column<decimal>(type: "Money", nullable: false),
                    DiscountAmount = table.Column<decimal>(type: "Money", nullable: false),
                    TaxRate = table.Column<int>(type: "Int", nullable: false),
                    SubTotal = table.Column<decimal>(type: "Money", nullable: false),
                    TaxTotal = table.Column<decimal>(type: "Money", nullable: false),
                    NetTotal = table.Column<decimal>(type: "Money", nullable: false),
                    Description = table.Column<string>(type: "VarChar(250)", maxLength: 250, nullable: true),
                    StoreId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppInvoiceDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppInvoiceDetails_AppExpenses_ExpenseId",
                        column: x => x.ExpenseId,
                        principalTable: "AppExpenses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppInvoiceDetails_AppInvoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "AppInvoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppInvoiceDetails_AppServices_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "AppServices",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppInvoiceDetails_AppStocks_StockId",
                        column: x => x.StockId,
                        principalTable: "AppStocks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppInvoiceDetails_AppStores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "AppStores",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AppReceipts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReceiptType = table.Column<byte>(type: "TinyInt", nullable: false),
                    ReceiptNumber = table.Column<string>(type: "VarChar(16)", maxLength: 16, nullable: false),
                    ReceiptDate = table.Column<DateTime>(type: "Date", nullable: false),
                    CurrentId = table.Column<Guid>(type: "UniqueIdentifier", nullable: true),
                    SafeId = table.Column<Guid>(type: "UniqueIdentifier", nullable: true),
                    BankAccountId = table.Column<Guid>(type: "UniqueIdentifier", nullable: true),
                    MovementNumber = table.Column<int>(type: "int", nullable: false),
                    ChequeTotal = table.Column<decimal>(type: "Money", nullable: false),
                    BillTotal = table.Column<decimal>(type: "Money", nullable: false),
                    PostTotal = table.Column<decimal>(type: "Money", nullable: false),
                    CashTotal = table.Column<decimal>(type: "Money", nullable: false),
                    BankTotal = table.Column<decimal>(type: "Money", nullable: false),
                    SpecialCodeOneId = table.Column<Guid>(type: "UniqueIdentifier", nullable: true),
                    SpecialCodeTwoId = table.Column<Guid>(type: "UniqueIdentifier", nullable: true),
                    DepartmentId = table.Column<Guid>(type: "UniqueIdentifier", nullable: false),
                    TermId = table.Column<Guid>(type: "UniqueIdentifier", nullable: false),
                    Description = table.Column<string>(type: "VarChar(250)", maxLength: 250, nullable: true),
                    Active = table.Column<bool>(type: "Bit", nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppReceipts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppReceipts_AppBankAccounts_BankAccountId",
                        column: x => x.BankAccountId,
                        principalTable: "AppBankAccounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppReceipts_AppCurrents_CurrentId",
                        column: x => x.CurrentId,
                        principalTable: "AppCurrents",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppReceipts_AppDepartments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "AppDepartments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppReceipts_AppSafes_SafeId",
                        column: x => x.SafeId,
                        principalTable: "AppSafes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppReceipts_AppSpecialCodes_SpecialCodeOneId",
                        column: x => x.SpecialCodeOneId,
                        principalTable: "AppSpecialCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppReceipts_AppSpecialCodes_SpecialCodeTwoId",
                        column: x => x.SpecialCodeTwoId,
                        principalTable: "AppSpecialCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppReceipts_AppTerms_TermId",
                        column: x => x.TermId,
                        principalTable: "AppTerms",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AppReceiptDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReceiptId = table.Column<Guid>(type: "UniqueIdentifier", nullable: false),
                    PaymentType = table.Column<byte>(type: "TinyInt", nullable: false),
                    TrackingNumber = table.Column<string>(type: "VarChar(50)", maxLength: 50, nullable: true),
                    ChequeBankId = table.Column<Guid>(type: "UniqueIdentifier", nullable: true),
                    ChequeBankDepartmentId = table.Column<Guid>(type: "UniqueIdentifier", nullable: true),
                    ChequeAccountNumber = table.Column<string>(type: "VarChar(16)", maxLength: 16, nullable: true),
                    DocumentNo = table.Column<string>(type: "VarChar(50)", maxLength: 50, nullable: true),
                    ExpiryDate = table.Column<DateTime>(type: "Date", nullable: false),
                    PrincipalDebtor = table.Column<string>(type: "VarChar(50)", maxLength: 50, nullable: true),
                    Endorser = table.Column<string>(type: "VarChar(50)", maxLength: 50, nullable: true),
                    SafeId = table.Column<Guid>(type: "UniqueIdentifier", nullable: true),
                    BankAccountId = table.Column<Guid>(type: "UniqueIdentifier", nullable: true),
                    Price = table.Column<decimal>(type: "Money", nullable: false),
                    DocumentStatu = table.Column<byte>(type: "TinyInt", nullable: false),
                    MyDocument = table.Column<bool>(type: "Bit", nullable: false),
                    Description = table.Column<string>(type: "VarChar(250)", maxLength: 250, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppReceiptDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppReceiptDetails_AppBankAccounts_BankAccountId",
                        column: x => x.BankAccountId,
                        principalTable: "AppBankAccounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppReceiptDetails_AppBankDepartments_ChequeBankDepartmentId",
                        column: x => x.ChequeBankDepartmentId,
                        principalTable: "AppBankDepartments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppReceiptDetails_AppBanks_ChequeBankId",
                        column: x => x.ChequeBankId,
                        principalTable: "AppBanks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppReceiptDetails_AppReceipts_ReceiptId",
                        column: x => x.ReceiptId,
                        principalTable: "AppReceipts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppReceiptDetails_AppSafes_SafeId",
                        column: x => x.SafeId,
                        principalTable: "AppSafes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppBankAccounts_BankDepartmentId",
                table: "AppBankAccounts",
                column: "BankDepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AppBankAccounts_Code",
                table: "AppBankAccounts",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_AppBankAccounts_DepartmentId",
                table: "AppBankAccounts",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AppBankAccounts_SpecialCodeOneId",
                table: "AppBankAccounts",
                column: "SpecialCodeOneId");

            migrationBuilder.CreateIndex(
                name: "IX_AppBankAccounts_SpecialCodeTwoId",
                table: "AppBankAccounts",
                column: "SpecialCodeTwoId");

            migrationBuilder.CreateIndex(
                name: "IX_AppBankDepartments_BankId",
                table: "AppBankDepartments",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_AppBankDepartments_Code",
                table: "AppBankDepartments",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_AppBankDepartments_SpecialCodeOneId",
                table: "AppBankDepartments",
                column: "SpecialCodeOneId");

            migrationBuilder.CreateIndex(
                name: "IX_AppBankDepartments_SpecialCodeTwoId",
                table: "AppBankDepartments",
                column: "SpecialCodeTwoId");

            migrationBuilder.CreateIndex(
                name: "IX_AppBanks_Code",
                table: "AppBanks",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_AppBanks_SpecialCodeOneId",
                table: "AppBanks",
                column: "SpecialCodeOneId");

            migrationBuilder.CreateIndex(
                name: "IX_AppBanks_SpecialCodeTwoId",
                table: "AppBanks",
                column: "SpecialCodeTwoId");

            migrationBuilder.CreateIndex(
                name: "IX_AppCurrents_Code",
                table: "AppCurrents",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_AppCurrents_CurrentId",
                table: "AppCurrents",
                column: "CurrentId");

            migrationBuilder.CreateIndex(
                name: "IX_AppCurrents_SpecialCodeOneId",
                table: "AppCurrents",
                column: "SpecialCodeOneId");

            migrationBuilder.CreateIndex(
                name: "IX_AppCurrents_SpecialCodeTwoId",
                table: "AppCurrents",
                column: "SpecialCodeTwoId");

            migrationBuilder.CreateIndex(
                name: "IX_AppDepartments_Code",
                table: "AppDepartments",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_AppExpenses_Code",
                table: "AppExpenses",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_AppExpenses_SpecialCodeOneId",
                table: "AppExpenses",
                column: "SpecialCodeOneId");

            migrationBuilder.CreateIndex(
                name: "IX_AppExpenses_SpecialCodeTwoId",
                table: "AppExpenses",
                column: "SpecialCodeTwoId");

            migrationBuilder.CreateIndex(
                name: "IX_AppExpenses_UnitId",
                table: "AppExpenses",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_AppInvoiceDetails_ExpenseId",
                table: "AppInvoiceDetails",
                column: "ExpenseId");

            migrationBuilder.CreateIndex(
                name: "IX_AppInvoiceDetails_InvoiceId",
                table: "AppInvoiceDetails",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_AppInvoiceDetails_ServiceId",
                table: "AppInvoiceDetails",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_AppInvoiceDetails_StockId",
                table: "AppInvoiceDetails",
                column: "StockId");

            migrationBuilder.CreateIndex(
                name: "IX_AppInvoiceDetails_StoreId",
                table: "AppInvoiceDetails",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_AppInvoices_CurrentId",
                table: "AppInvoices",
                column: "CurrentId");

            migrationBuilder.CreateIndex(
                name: "IX_AppInvoices_DepartmentId",
                table: "AppInvoices",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AppInvoices_InvoiceNumber",
                table: "AppInvoices",
                column: "InvoiceNumber");

            migrationBuilder.CreateIndex(
                name: "IX_AppInvoices_SpecialCodeOneId",
                table: "AppInvoices",
                column: "SpecialCodeOneId");

            migrationBuilder.CreateIndex(
                name: "IX_AppInvoices_SpecialCodeTwoId",
                table: "AppInvoices",
                column: "SpecialCodeTwoId");

            migrationBuilder.CreateIndex(
                name: "IX_AppInvoices_TermId",
                table: "AppInvoices",
                column: "TermId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOrganizationParameters_DepartmentId",
                table: "AppOrganizationParameters",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOrganizationParameters_StoreId",
                table: "AppOrganizationParameters",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOrganizationParameters_TermId",
                table: "AppOrganizationParameters",
                column: "TermId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOrganizationParameters_UserId",
                table: "AppOrganizationParameters",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppReceiptDetails_BankAccountId",
                table: "AppReceiptDetails",
                column: "BankAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AppReceiptDetails_ChequeBankDepartmentId",
                table: "AppReceiptDetails",
                column: "ChequeBankDepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AppReceiptDetails_ChequeBankId",
                table: "AppReceiptDetails",
                column: "ChequeBankId");

            migrationBuilder.CreateIndex(
                name: "IX_AppReceiptDetails_ReceiptId",
                table: "AppReceiptDetails",
                column: "ReceiptId");

            migrationBuilder.CreateIndex(
                name: "IX_AppReceiptDetails_SafeId",
                table: "AppReceiptDetails",
                column: "SafeId");

            migrationBuilder.CreateIndex(
                name: "IX_AppReceiptDetails_TrackingNumber",
                table: "AppReceiptDetails",
                column: "TrackingNumber");

            migrationBuilder.CreateIndex(
                name: "IX_AppReceipts_BankAccountId",
                table: "AppReceipts",
                column: "BankAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AppReceipts_CurrentId",
                table: "AppReceipts",
                column: "CurrentId");

            migrationBuilder.CreateIndex(
                name: "IX_AppReceipts_DepartmentId",
                table: "AppReceipts",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AppReceipts_ReceiptNumber",
                table: "AppReceipts",
                column: "ReceiptNumber");

            migrationBuilder.CreateIndex(
                name: "IX_AppReceipts_SafeId",
                table: "AppReceipts",
                column: "SafeId");

            migrationBuilder.CreateIndex(
                name: "IX_AppReceipts_SpecialCodeOneId",
                table: "AppReceipts",
                column: "SpecialCodeOneId");

            migrationBuilder.CreateIndex(
                name: "IX_AppReceipts_SpecialCodeTwoId",
                table: "AppReceipts",
                column: "SpecialCodeTwoId");

            migrationBuilder.CreateIndex(
                name: "IX_AppReceipts_TermId",
                table: "AppReceipts",
                column: "TermId");

            migrationBuilder.CreateIndex(
                name: "IX_AppSafes_Code",
                table: "AppSafes",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_AppSafes_DepartmentId",
                table: "AppSafes",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AppSafes_SpecialCodeOneId",
                table: "AppSafes",
                column: "SpecialCodeOneId");

            migrationBuilder.CreateIndex(
                name: "IX_AppSafes_SpecialCodeTwoId",
                table: "AppSafes",
                column: "SpecialCodeTwoId");

            migrationBuilder.CreateIndex(
                name: "IX_AppServices_Barcode",
                table: "AppServices",
                column: "Barcode");

            migrationBuilder.CreateIndex(
                name: "IX_AppServices_Code",
                table: "AppServices",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_AppServices_SpecialCodeOneId",
                table: "AppServices",
                column: "SpecialCodeOneId");

            migrationBuilder.CreateIndex(
                name: "IX_AppServices_SpecialCodeTwoId",
                table: "AppServices",
                column: "SpecialCodeTwoId");

            migrationBuilder.CreateIndex(
                name: "IX_AppServices_UnitId",
                table: "AppServices",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_AppSpecialCodes_Code",
                table: "AppSpecialCodes",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_AppStocks_Barcode",
                table: "AppStocks",
                column: "Barcode");

            migrationBuilder.CreateIndex(
                name: "IX_AppStocks_Code",
                table: "AppStocks",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_AppStocks_SpecialCodeOneId",
                table: "AppStocks",
                column: "SpecialCodeOneId");

            migrationBuilder.CreateIndex(
                name: "IX_AppStocks_SpecialCodeTwoId",
                table: "AppStocks",
                column: "SpecialCodeTwoId");

            migrationBuilder.CreateIndex(
                name: "IX_AppStocks_UnitId",
                table: "AppStocks",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_AppStores_Code",
                table: "AppStores",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_AppStores_DepartmentId",
                table: "AppStores",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AppStores_SpecialCodeOneId",
                table: "AppStores",
                column: "SpecialCodeOneId");

            migrationBuilder.CreateIndex(
                name: "IX_AppStores_SpecialCodeTwoId",
                table: "AppStores",
                column: "SpecialCodeTwoId");

            migrationBuilder.CreateIndex(
                name: "IX_AppTerms_Code",
                table: "AppTerms",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_AppUnits_Code",
                table: "AppUnits",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_AppUnits_SpecialCodeOneId",
                table: "AppUnits",
                column: "SpecialCodeOneId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUnits_SpecialCodeTwoId",
                table: "AppUnits",
                column: "SpecialCodeTwoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppInvoiceDetails");

            migrationBuilder.DropTable(
                name: "AppOrganizationParameters");

            migrationBuilder.DropTable(
                name: "AppReceiptDetails");

            migrationBuilder.DropTable(
                name: "AppExpenses");

            migrationBuilder.DropTable(
                name: "AppInvoices");

            migrationBuilder.DropTable(
                name: "AppServices");

            migrationBuilder.DropTable(
                name: "AppStocks");

            migrationBuilder.DropTable(
                name: "AppStores");

            migrationBuilder.DropTable(
                name: "AppReceipts");

            migrationBuilder.DropTable(
                name: "AppUnits");

            migrationBuilder.DropTable(
                name: "AppBankAccounts");

            migrationBuilder.DropTable(
                name: "AppCurrents");

            migrationBuilder.DropTable(
                name: "AppSafes");

            migrationBuilder.DropTable(
                name: "AppTerms");

            migrationBuilder.DropTable(
                name: "AppBankDepartments");

            migrationBuilder.DropTable(
                name: "AppDepartments");

            migrationBuilder.DropTable(
                name: "AppBanks");

            migrationBuilder.DropTable(
                name: "AppSpecialCodes");
        }
    }
}
