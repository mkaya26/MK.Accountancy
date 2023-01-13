using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MK.Accountancy.Migrations
{
    public partial class DbSchemaReplace : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "MHSB");

            migrationBuilder.RenameTable(
                name: "AppUnits",
                newName: "AppUnits",
                newSchema: "MHSB");

            migrationBuilder.RenameTable(
                name: "AppTerms",
                newName: "AppTerms",
                newSchema: "MHSB");

            migrationBuilder.RenameTable(
                name: "AppStores",
                newName: "AppStores",
                newSchema: "MHSB");

            migrationBuilder.RenameTable(
                name: "AppStocks",
                newName: "AppStocks",
                newSchema: "MHSB");

            migrationBuilder.RenameTable(
                name: "AppSpecialCodes",
                newName: "AppSpecialCodes",
                newSchema: "MHSB");

            migrationBuilder.RenameTable(
                name: "AppServices",
                newName: "AppServices",
                newSchema: "MHSB");

            migrationBuilder.RenameTable(
                name: "AppSafes",
                newName: "AppSafes",
                newSchema: "MHSB");

            migrationBuilder.RenameTable(
                name: "AppReceipts",
                newName: "AppReceipts",
                newSchema: "MHSB");

            migrationBuilder.RenameTable(
                name: "AppReceiptDetails",
                newName: "AppReceiptDetails",
                newSchema: "MHSB");

            migrationBuilder.RenameTable(
                name: "AppOrganizationParameters",
                newName: "AppOrganizationParameters",
                newSchema: "MHSB");

            migrationBuilder.RenameTable(
                name: "AppInvoices",
                newName: "AppInvoices",
                newSchema: "MHSB");

            migrationBuilder.RenameTable(
                name: "AppInvoiceDetails",
                newName: "AppInvoiceDetails",
                newSchema: "MHSB");

            migrationBuilder.RenameTable(
                name: "AppExpenses",
                newName: "AppExpenses",
                newSchema: "MHSB");

            migrationBuilder.RenameTable(
                name: "AppDepartments",
                newName: "AppDepartments",
                newSchema: "MHSB");

            migrationBuilder.RenameTable(
                name: "AppCurrents",
                newName: "AppCurrents",
                newSchema: "MHSB");

            migrationBuilder.RenameTable(
                name: "AppBanks",
                newName: "AppBanks",
                newSchema: "MHSB");

            migrationBuilder.RenameTable(
                name: "AppBankDepartments",
                newName: "AppBankDepartments",
                newSchema: "MHSB");

            migrationBuilder.RenameTable(
                name: "AppBankAccounts",
                newName: "AppBankAccounts",
                newSchema: "MHSB");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "AppUnits",
                schema: "MHSB",
                newName: "AppUnits");

            migrationBuilder.RenameTable(
                name: "AppTerms",
                schema: "MHSB",
                newName: "AppTerms");

            migrationBuilder.RenameTable(
                name: "AppStores",
                schema: "MHSB",
                newName: "AppStores");

            migrationBuilder.RenameTable(
                name: "AppStocks",
                schema: "MHSB",
                newName: "AppStocks");

            migrationBuilder.RenameTable(
                name: "AppSpecialCodes",
                schema: "MHSB",
                newName: "AppSpecialCodes");

            migrationBuilder.RenameTable(
                name: "AppServices",
                schema: "MHSB",
                newName: "AppServices");

            migrationBuilder.RenameTable(
                name: "AppSafes",
                schema: "MHSB",
                newName: "AppSafes");

            migrationBuilder.RenameTable(
                name: "AppReceipts",
                schema: "MHSB",
                newName: "AppReceipts");

            migrationBuilder.RenameTable(
                name: "AppReceiptDetails",
                schema: "MHSB",
                newName: "AppReceiptDetails");

            migrationBuilder.RenameTable(
                name: "AppOrganizationParameters",
                schema: "MHSB",
                newName: "AppOrganizationParameters");

            migrationBuilder.RenameTable(
                name: "AppInvoices",
                schema: "MHSB",
                newName: "AppInvoices");

            migrationBuilder.RenameTable(
                name: "AppInvoiceDetails",
                schema: "MHSB",
                newName: "AppInvoiceDetails");

            migrationBuilder.RenameTable(
                name: "AppExpenses",
                schema: "MHSB",
                newName: "AppExpenses");

            migrationBuilder.RenameTable(
                name: "AppDepartments",
                schema: "MHSB",
                newName: "AppDepartments");

            migrationBuilder.RenameTable(
                name: "AppCurrents",
                schema: "MHSB",
                newName: "AppCurrents");

            migrationBuilder.RenameTable(
                name: "AppBanks",
                schema: "MHSB",
                newName: "AppBanks");

            migrationBuilder.RenameTable(
                name: "AppBankDepartments",
                schema: "MHSB",
                newName: "AppBankDepartments");

            migrationBuilder.RenameTable(
                name: "AppBankAccounts",
                schema: "MHSB",
                newName: "AppBankAccounts");
        }
    }
}
