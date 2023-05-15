using MK.Accountancy.Blazor.Services.Base;
using MK.Accountancy.PaymentDocuments;
using MK.Accountancy.Receipts;
using System.Linq;
using Volo.Abp.DependencyInjection;

namespace MK.Accountancy.Blazor.Services
{
    public class PaymentDocumentService : BaseService<ListPaymentDocumentDto,SelectReceiptDetailDto>,IScopedDependency
    {
        public AppService AppService { get; set; }
        public ReceiptService ReceiptService { get; set; }
        public ReceiptMoventService ReceiptMoventService { get; set; }
        public string PaymentTypes { get; set; }
        public bool MyDocument { get; set; }
        public void NegotiableDocuments(string paymentTypes)
        {
            BeforeShowPopupListPage();
            PaymentTypes = paymentTypes;
            ShowSelectionCheckBox = true;
            ExcludeListItem = ReceiptMoventService.ListDataSource.Where(x => x.DocumentStatu == DocumentStatu.Endorsed ||
              x.DocumentStatu == DocumentStatu.Collected ||
              x.DocumentStatu == DocumentStatu.Paid)
                .Select(x => x.TrackingNumber).ToList();
        }
        public override void AddSelectedItems()
        {
            if(SelectedItems == null)
            {
                return;
            }
            //
            foreach(var item in SelectedItems)
            {
                item.Id = GuidGenerator.Create();
                item.DocumentStatu = (
                    ReceiptService.ReceiptType == ReceiptType.SafeOperation ||
                    ReceiptService.ReceiptType == ReceiptType.BankOperation) && 
                    item.MyDocument ? DocumentStatu.Paid :
                    (ReceiptService.ReceiptType == ReceiptType.SafeOperation ||
                    ReceiptService.ReceiptType == ReceiptType.BankOperation) && 
                    !item.MyDocument ? DocumentStatu.Collected : DocumentStatu.Endorsed;
                item.SafeId = ReceiptService.ReceiptType == ReceiptType.SafeOperation ? ReceiptService.DataSource.SafeId : null;
                item.BankAccountId = ReceiptService.ReceiptType == ReceiptType.BankOperation ? ReceiptService.DataSource.BankAccountId : null;
                //
                var mappedDto = ObjectMapper.Map<ListPaymentDocumentDto,SelectReceiptDetailDto>(item);
                mappedDto.PaymentTypeName = L[$"Enum:PaymentType:{(byte)mappedDto.PaymentType}"];
                mappedDto.DocumentStatuName = L[$"Enum:DocumentStatu:{(byte)mappedDto.DocumentStatu}"];
                //
                ReceiptMoventService.ListDataSource.Add(mappedDto);
            }
            HideEditPage();
            ReceiptMoventService.SetDataRowSelected(false);
            ReceiptMoventService.GetTotal();
        }
    }
}
