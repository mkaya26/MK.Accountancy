using MK.Accountancy.Receipts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MK.Accountancy.Reports
{
    public interface IFinancialStatuAppService
    {
        Task<IList<FinanceMoventDto>> SafeLastTenMovesListAsync(ReceiptDetailListParameterDto input);
        Task<IList<FinanceMoventDto>> BankLastTenMovesListAsync(ReceiptDetailListParameterDto input);
        Task<IList<FinancialStatusDto>> SafeStatuListAsync(ReceiptDetailListParameterDto input);
        Task<IList<FinancialStatusDto>> BankStatuListAsync(ReceiptDetailListParameterDto input);
        Task<IList<FinancialStatusDto>> DistributionoPaymentDocumentListAsync
(ReceiptDetailListParameterDto input);
        Task<IList<PaymentDocumentDto>> OverdueReceivablesListAsync(ReceiptDetailListParameterDto input);
    }
}
