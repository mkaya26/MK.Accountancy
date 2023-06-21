using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MK.Accountancy.Migrations
{
    public partial class Company : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppCompanies",
                schema: "MHSB",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "VarChar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "VarChar(250)", maxLength: 250, nullable: true),
                    Telephone = table.Column<string>(type: "VarChar(15)", maxLength: 15, nullable: true),
                    Email = table.Column<string>(type: "VarChar(255)", maxLength: 255, nullable: true),
                    WebAddress = table.Column<string>(type: "VarChar(255)", maxLength: 255, nullable: true),
                    Bank = table.Column<string>(type: "VarChar(50)", maxLength: 50, nullable: true),
                    BankDepartment = table.Column<string>(type: "VarChar(50)", maxLength: 50, nullable: true),
                    BankAccountNumber = table.Column<string>(type: "VarChar(20)", maxLength: 20, nullable: false),
                    BankIbanNumber = table.Column<string>(type: "VarChar(26)", maxLength: 26, nullable: true),
                    LogoUrl = table.Column<string>(type: "VarChar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppCompanies", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppCompanies",
                schema: "MHSB");
        }
    }
}
