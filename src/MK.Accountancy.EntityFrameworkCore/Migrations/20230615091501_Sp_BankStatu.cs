using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MK.Accountancy.Migrations
{
    public partial class Sp_BankStatu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sqlProc = @"IF OBJECT_ID('MHSB.BankStatu', 'P') IS NOT NULL
    DROP PROCEDURE MHSB.BankStatu
GO
CREATE PROCEDURE [MHSB].[BankStatu] @DepartmentId uniqueidentifier,
                                    @TermId uniqueidentifier
AS
BEGIN
    DECLARE
        @Income MONEY,
        @Expense MONEY
    SET NOCOUNT ON;
    SELECT @Income = COALESCE(SUM(Price), 0)
    FROM MHSB.AppReceiptDetails mbh
             LEFT JOIN
         MHSB.AppReceipts mb ON mbh.ReceiptId = mb.Id
    WHERE mbh.BankAccountId IS NOT NULL
      AND (mb.ReceiptType = 1 OR (mb.ReceiptType = 4 AND mbh.MyDocument = 0))
      AND mb.DepartmentId = CONVERT(varchar(MAX), @DepartmentId)
      AND mb.TermId = CONVERT(varchar(MAX), @TermId)
      AND mbh.IsDeleted = 0
    SELECT @Expense = COALESCE(SUM(Price), 0)
    FROM MHSB.AppReceiptDetails mbh
             LEFT JOIN
         MHSB.AppReceipts mb ON mbh.ReceiptId = mb.Id
    WHERE mbh.BankAccountId IS NOT NULL
      AND (mb.ReceiptType = 2 OR (mb.ReceiptType = 4 AND mbh.MyDocument = 1))
      AND mb.DepartmentId = CONVERT(varchar(MAX), @DepartmentId)
      AND mb.TermId = CONVERT(varchar(MAX), @TermId)
      AND mbh.IsDeleted = 0
    Select @Income as Income, @Expense As Expense, @Income - @Expense As Balance
END";
            migrationBuilder.Sql(sqlProc);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sqlProc = "DROP PROC MHSB.BankStatu";
            migrationBuilder.Sql(sqlProc);
        }
    }
}
