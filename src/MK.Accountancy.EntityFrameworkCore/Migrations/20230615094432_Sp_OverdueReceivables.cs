using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MK.Accountancy.Migrations
{
    public partial class Sp_OverdueReceivables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sqlProc = @"IF OBJECT_ID('MHSB.OverdueReceivables', 'P') IS NOT NULL
    DROP PROCEDURE MHSB.OverdueReceivables
GO
CREATE PROCEDURE [MHSB].[OverdueReceivables] @DepartmentId uniqueidentifier,
                                             @TermId uniqueidentifier,
                                             @PaymentTypes Varchar(100),
                                             @Date datetime
AS
BEGIN
    SET NOCOUNT ON
    DECLARE @SQL VARCHAR(MAX)
    SET @SQL = 'SELECT MAX(rd.Id)             AS Id,
       MAX(rd.ReceiptId)      AS ReceiptId,
       MAX(rd.BankAccountId)  AS BankAccountId,
       MAX(ba.Name)           AS BankAccountName,
       rd.ChequeBankId,
       b.Name                 AS ChequeBankName,
       rd.ChequeBankDepartmentId,
       bd.Name                AS ChequeBankDepartmentName,
       rd.Description,
       rd.PrincipalDebtor,
       MAX(rd.DocumentStatu)  AS DocumentStatu,
       rd.DocumentNo,
       rd.ChequeAccountNumber,
       rd.Endorser,
       rd.PaymentType,
       rd.Price,
       rd.ExpiryDate,
       r.TermId,
       r.DepartmentId,
       MAX(rd.TrackingNumber) AS TrackingNumber,
       rd.MyDocument,
       rd.IsDeleted
FROM MHSB.AppReceiptDetails rd
         LEFT OUTER JOIN
     MHSB.AppReceipts r ON rd.ReceiptId = r.Id
         LEFT OUTER JOIN
     MHSB.AppBanks b ON rd.ChequeBankId = b.Id
         LEFT OUTER JOIN
     MHSB.AppBankDepartments bd ON rd.ChequeBankDepartmentId = bd.Id
         LEFT OUTER JOIN
     MHSB.AppBankAccounts ba ON rd.BankAccountId = ba.Id
GROUP BY rd.ChequeBankId, rd.ChequeBankDepartmentId, rd.Description,
         rd.PrincipalDebtor, rd.ChequeAccountNumber, rd.Endorser,
         rd.Price, rd.ExpiryDate, rd.DocumentNo,
         rd.MyDocument, b.Name, bd.Name,
         r.TermId, r.DepartmentId, rd.PaymentType,
         rd.MyDocument, rd.IsDeleted
HAVING (COUNT(rd.TrackingNumber) = 1)
   AND r.DepartmentId = ''' + CONVERT(varchar(MAX), @DepartmentId) + '''
   AND r.TermId = ''' + CONVERT(varchar(MAX), @TermId) + '''
   AND rd.PaymentType IN (' + @PaymentTypes + ')
   AND rd.ExpiryDate < ''' + CONVERT(varchar, @Date) + '''
   AND rd.MyDocument = 0
   AND rd.IsDeleted = 0
ORDER BY rd.ExpiryDate'
END
    EXEC (@SQL);";
            migrationBuilder.Sql(sqlProc);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sqlProc = "DROP PROC MHSB.OverdueReceivables";
            migrationBuilder.Sql(sqlProc);
        }
    }
}
