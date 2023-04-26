using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MK.Accountancy.Migrations
{
    public partial class _26042023 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StoryId",
                schema: "MHSB",
                table: "AppInvoiceDetails");

            migrationBuilder.AlterColumn<Guid>(
                name: "StoreId",
                schema: "MHSB",
                table: "AppInvoiceDetails",
                type: "UniqueIdentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "StoreId",
                schema: "MHSB",
                table: "AppInvoiceDetails",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "UniqueIdentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "StoryId",
                schema: "MHSB",
                table: "AppInvoiceDetails",
                type: "UniqueIdentifier",
                nullable: true);
        }
    }
}
