using DevExpress.Blazor.Internal;
using MK.Accountancy.Blazor.Services;
using MK.Accountancy.PaymentDocuments;
using MK.Accountancy.Receipts;
using System.Linq;
using System.Threading.Tasks;

namespace MK.Accountancy.Blazor.Pages.PaymentDocuments
{
    public partial class PaymentDocumentListPage
    {
        public AppService AppService { get; set; }
        protected override async Task GetListDataSourceAsync()
        {
            if(!Service.IsPopupListPage)
            {
                Service.ReceiptService.ReceiptType = 0;
                Service.PaymentTypes = $"{(byte)PaymentType.Cheque},{(byte)PaymentType.Bill},{(byte)PaymentType.Pos}";
                Service.MyDocument = false;
            }
            //
            Service.ListDataSource = (await GetListAsync(new PaymentDocumentListParameterDto
            {
                Sql = Service.ReceiptService.ReceiptType == ReceiptType.BankOperation || Service.ReceiptService.ReceiptType == ReceiptType.SafeOperation ? "MHSB.Sp_AllTransactionablePaymentDocuments" : Service.ReceiptService.ReceiptType == ReceiptType.Payment ? "MHSB.Sp_TransactionablePaymentDocuments" : "MHSB.Sp_PaymentDocuments",
                DepartmentId = AppService.CompanyParameter.DepartmentId,
                TermId = AppService.CompanyParameter.TermId,
                MyDocument = Service.MyDocument,
                PaymentTypes = Service.PaymentTypes
            })).Items.ToList();
            //
            Service.ExcludeListItem.ForEach(x =>
            {
                var entity = Service.ListDataSource.FirstOrDefault(y => y.TrackingNumber == x);
                Service.ListDataSource.Remove(entity);
            });
            //
            Service.ExcludeListItem = null;
            Service.IsLoaded = true;
        }
    }
}
