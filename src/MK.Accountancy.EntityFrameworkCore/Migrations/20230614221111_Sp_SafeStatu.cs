using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MK.Accountancy.Migrations
{
    public partial class Sp_SafeStatu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sqlProc = @"IF OBJECT_ID('MHSB.SafeStatu', 'P') IS NOT NULL
    DROP PROCEDURE MHSB.SafeStatu
GO
CREATE PROCEDURE [MHSB].[SafeStatu] @DepartmentId uniqueidentifier,
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
    WHERE mbh.SafeId IS NOT NULL
      AND (mb.ReceiptType = 1 OR (mb.ReceiptType = 3 AND mbh.MyDocument = 0))
      AND mb.DepartmentId = CONVERT(varchar(MAX), @DepartmentId)
      AND mb.TermId = CONVERT(varchar(MAX), @TermId)
      AND mbh.IsDeleted = 0
    SELECT @Expense = COALESCE(SUM(Price), 0)
    FROM MHSB.AppReceiptDetails mbh
             LEFT JOIN
         MHSB.AppReceipts mb ON mbh.ReceiptId = mb.Id
    WHERE mbh.SafeId IS NOT NULL
      AND (mb.ReceiptType = 2 OR (mb.ReceiptType = 3 AND mbh.MyDocument = 1))
      AND mb.DepartmentId = CONVERT(varchar(MAX), @DepartmentId)
      AND mb.TermId = CONVERT(varchar(MAX), @TermId)
      AND mbh.IsDeleted = 0
    Select @Income as Income, @Expense As Expense, @Income - @Expense As Balance
END";
            migrationBuilder.Sql(sqlProc);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sqlProc = "DROP PROC MHSB.SafeStatu";
            migrationBuilder.Sql(sqlProc);
        }
    }
}
