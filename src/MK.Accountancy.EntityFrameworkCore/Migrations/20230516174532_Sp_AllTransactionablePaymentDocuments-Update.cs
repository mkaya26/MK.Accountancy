using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MK.Accountancy.Migrations
{
    public partial class Sp_AllTransactionablePaymentDocumentsUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sqlProc = @"IF OBJECT_ID('MHSB.Sp_AllTransactionablePaymentDocuments', 'P') IS NOT NULL
    DROP PROCEDURE MHSB.Sp_AllTransactionablePaymentDocuments
GO
CREATE PROCEDURE [MHSB].[Sp_AllTransactionablePaymentDocuments] @DepartmentId uniqueidentifier,
                                                                      @TermId uniqueidentifier,
                                                                      @PaymentTypes Varchar(100)
AS
BEGIN
    SET NOCOUNT ON
    DECLARE @SQL VARCHAR(MAX)


    SET @SQL = 'SELECT MAX(ReceiptDetails.Id)           AS Id,
       MAX(ReceiptDetails.ReceiptId)     AS ReceiptId,
       MAX(ReceiptDetails.BankAccountId) AS BankAccountId,
       MAX(BankAccount.Name)              AS BankAccountName,
       ReceiptDetails.ChequeBankId,
       Bank.Name                        AS ChequeBankName,
       ReceiptDetails.ChequeBankDepartmentId,
       BankDepartment.Name                    AS ChequeBankDepartmentName,
       ReceiptDetails.Description,
       ReceiptDetails.PrincipalDebtor,
       MAX(ReceiptDetails.DocumentStatu)  AS DocumentStatu,
       ReceiptDetails.DocumentNo,
       ReceiptDetails.ChequeAccountNumber,
       ReceiptDetails.Endorser,
       ReceiptDetails.PaymentType,
       ReceiptDetails.Price,
       ReceiptDetails.ExpiryDate,
       Receipt.TermId,
       Receipt.DepartmentId,
       MAX(ReceiptDetails.TrackingNumber)      AS TrackingNumber,
       ReceiptDetails.MyDocument,
       ReceiptDetails.IsDeleted
FROM MHSB.AppReceiptDetails ReceiptDetails
         LEFT OUTER JOIN
     MHSB.AppReceipts Receipt ON ReceiptDetails.ReceiptId = Receipt.Id
         LEFT OUTER JOIN
     MHSB.AppBanks Bank ON ReceiptDetails.ChequeBankId = Bank.Id
         LEFT OUTER JOIN
     MHSB.AppBankDepartments BankDepartment ON ReceiptDetails.ChequeBankDepartmentId = BankDepartment.Id
         LEFT OUTER JOIN
     MHSB.AppBankAccounts BankAccount ON ReceiptDetails.BankAccountId = BankAccount.Id

GROUP BY
       ReceiptDetails.ChequeBankId,
       Bank.Name,
       ReceiptDetails.ChequeBankDepartmentId,
       BankDepartment.Name,
       ReceiptDetails.Description,
       ReceiptDetails.PrincipalDebtor,
       ReceiptDetails.DocumentNo,
       ReceiptDetails.ChequeAccountNumber,
       ReceiptDetails.Endorser,
       ReceiptDetails.PaymentType,
       ReceiptDetails.Price,
       ReceiptDetails.ExpiryDate,
       Receipt.TermId,
       Receipt.DepartmentId,
       ReceiptDetails.MyDocument,
       ReceiptDetails.IsDeleted
HAVING (COUNT(ReceiptDetails.TrackingNumber) = 1)
   AND Receipt.DepartmentId = ''' + CONVERT(varchar(MAX), @DepartmentId) + '''
   AND Receipt.TermId = ''' + CONVERT(varchar(MAX), @TermId) + '''
   AND ReceiptDetails.PaymentType IN (' + @PaymentTypes + ')
   AND ReceiptDetails.IsDeleted = 0
ORDER BY ReceiptDetails.ExpiryDate'
END

    EXEC (@SQL);";

            migrationBuilder.Sql(sqlProc);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sqlProc = "DROP PROC MHSB.Sp_AllTransactionablePaymentDocuments";
            migrationBuilder.Sql(sqlProc);
        }
    }
}
