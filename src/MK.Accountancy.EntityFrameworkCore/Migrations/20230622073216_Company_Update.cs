using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MK.Accountancy.Migrations
{
    public partial class Company_Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FullLogoUrl",
                schema: "MHSB",
                table: "AppCompanies",
                type: "VarChar(255)",
                maxLength: 255,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullLogoUrl",
                schema: "MHSB",
                table: "AppCompanies");
        }
    }
}
