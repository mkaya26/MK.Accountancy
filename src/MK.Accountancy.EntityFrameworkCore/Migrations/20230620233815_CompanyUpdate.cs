using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MK.Accountancy.Migrations
{
    public partial class CompanyUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "BankAccountNumber",
                schema: "MHSB",
                table: "AppCompanies",
                type: "VarChar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VarChar(20)",
                oldMaxLength: 20);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "BankAccountNumber",
                schema: "MHSB",
                table: "AppCompanies",
                type: "VarChar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "VarChar(20)",
                oldMaxLength: 20,
                oldNullable: true);
        }
    }
}
