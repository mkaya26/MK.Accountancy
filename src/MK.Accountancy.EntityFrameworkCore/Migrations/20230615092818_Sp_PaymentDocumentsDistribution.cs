using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MK.Accountancy.Migrations
{
    public partial class Sp_PaymentDocumentsDistribution : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sqlProc = @"IF OBJECT_ID('MHSB.PaymentDocumentsDistribution', 'P') IS NOT NULL
    DROP PROCEDURE MHSB.PaymentDocumentsDistribution
GO
CREATE PROCEDURE [MHSB].[PaymentDocumentsDistribution] @DepartmentId uniqueidentifier,
                                                       @TermId uniqueidentifier
AS
BEGIN
    SET NOCOUNT ON
    DECLARE @SQL VARCHAR(MAX)

    SET @SQL = 'SELECT MHSB.AppReceiptDetails.PaymentType, SUM(MHSB.AppReceiptDetails.Price) AS Amount
FROM MHSB.AppReceiptDetails
         LEFT OUTER JOIN
     MHSB.AppReceipts ON MHSB.AppReceiptDetails.ReceiptId = MHSB.AppReceipts.Id
GROUP BY MHSB.AppReceiptDetails.PaymentType, MHSB.AppReceipts.ReceiptType, MHSB.AppReceipts.TermId,
         MHSB.AppReceipts.DepartmentId, MHSB.AppReceiptDetails.IsDeleted
HAVING MHSB.AppReceipts.DepartmentId = ''' + CONVERT(varchar(MAX), @DepartmentId) + '''
   AND MHSB.AppReceipts.TermId = ''' + CONVERT(varchar(MAX), @TermId) + '''
   AND MHSB.AppReceipts.ReceiptType = 1
   AND MHSB.AppReceiptDetails.IsDeleted = 0 '
END
    EXEC (@SQL);";
            migrationBuilder.Sql(sqlProc);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sqlProc = "DROP PROC MHSB.PaymentDocumentsDistribution";
            migrationBuilder.Sql(sqlProc);
        }
    }
}
