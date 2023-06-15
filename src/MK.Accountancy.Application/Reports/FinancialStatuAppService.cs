using MK.Accountancy.BankAccounts;
using MK.Accountancy.PaymentDocuments;
using MK.Accountancy.Receipts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MK.Accountancy.Reports
{
    public class FinancialStatuAppService : AccountancyAppService, IFinancialStatuAppService
    {
        private readonly IReceiptDetailRepository _receiptDetailRepository;
        private readonly IIncomeExpenseBalanceRepository _incomeExpenseBalanceRepository;
        private readonly IPaymentDocumentsDistributionRepository _paymentDocumentsDistributionRepository;
        private readonly IPaymentDocumentRepository _paymentDocumentRepository;

        public FinancialStatuAppService(IReceiptDetailRepository receiptDetailRepository, IIncomeExpenseBalanceRepository incomeExpenseBalanceRepository, IPaymentDocumentsDistributionRepository paymentDocumentsDistributionRepository, IPaymentDocumentRepository paymentDocumentRepository)
        {
            _receiptDetailRepository = receiptDetailRepository;
            _incomeExpenseBalanceRepository = incomeExpenseBalanceRepository;
            _paymentDocumentsDistributionRepository = paymentDocumentsDistributionRepository;
            _paymentDocumentRepository = paymentDocumentRepository;
        }

        public virtual async Task<IList<FinanceMoventDto>> SafeLastTenMovesListAsync(ReceiptDetailListParameterDto input)
        {
            var movents = await _receiptDetailRepository.GetPagedLastListAsync(0, 10,
                f => f.Receipt.DepartmentId == input.DepartmentId &&
                     f.Receipt.TermId == input.TermId &&
                     f.SafeId != null,
                o => o.Id,
                i => i.Receipt);
            //
            var financeMovents = new List<FinanceMoventDto>();
            //
            movents.ForEach(x =>
            {
                financeMovents.Add(new FinanceMoventDto
                {
                    ReceiptNo = x.Receipt.ReceiptNumber,
                    Date = x.Receipt.ReceiptDate,
                    Debt = x.Receipt.ReceiptType == ReceiptType.Collection ||
                           x.Receipt.ReceiptType == ReceiptType.SafeOperation &&
                           !x.MyDocument ? x.Price : 0,
                    Receivable = x.Receipt.ReceiptType == ReceiptType.Payment ||
                           x.Receipt.ReceiptType == ReceiptType.SafeOperation &&
                           x.MyDocument ? x.Price : 0,
                    Description = x.Description
                });
            });
            //
            return financeMovents;
        }

        public virtual async Task<IList<FinanceMoventDto>> BankLastTenMovesListAsync(ReceiptDetailListParameterDto input)
        {
            var movents = await _receiptDetailRepository.GetPagedLastListAsync(0, 10,
                    f => f.Receipt.DepartmentId == input.DepartmentId &&
                         f.Receipt.TermId == input.TermId &&
                         f.BankAccountId != null &&
                         f.BankAccount.BankAccountType == BankAccountType.CurrentDepositAccount,
                    o => o.Id,
                    i => i.Receipt,
                    i => i.BankAccount);
            //
            var financeMovents = new List<FinanceMoventDto>();
            //
            movents.ForEach(x =>
            {
                financeMovents.Add(new FinanceMoventDto
                {
                    ReceiptNo = x.Receipt.ReceiptNumber,
                    Date = x.Receipt.ReceiptDate,
                    Debt = x.Receipt.ReceiptType == ReceiptType.Collection ||
                           x.Receipt.ReceiptType == ReceiptType.BankOperation &&
                           !x.MyDocument ? x.Price : 0,
                    Receivable = x.Receipt.ReceiptType == ReceiptType.Payment ||
                           x.Receipt.ReceiptType == ReceiptType.BankOperation &&
                           x.MyDocument ? x.Price : 0,
                    Description = x.Description
                });
            });
            //
            return financeMovents;
        }
        public virtual async Task<IList<FinancialStatusDto>> SafeStatuListAsync(ReceiptDetailListParameterDto input)
        {
            var safeStatu = await _incomeExpenseBalanceRepository
                .FromSqlRawSingleAsync($"MHSB.SafeStatu @DepartmentId='{input.DepartmentId}', @TermId='{input.TermId}'");
            //
            var list = new List<FinancialStatusDto>
            {
                new FinancialStatusDto
                {
                    Description = L["Income"],
                    Price = safeStatu.Income
                },
                new FinancialStatusDto
                {
                    Description = L["Expense"],
                    Price = safeStatu.Expense
                },
                new FinancialStatusDto
                {
                    Description = L["Balance"],
                    Price = safeStatu.Balance
                }
            };
            //
            return list;
        }

        public virtual async Task<IList<FinancialStatusDto>> BankStatuListAsync(ReceiptDetailListParameterDto input)
        {
            var safeStatu = await _incomeExpenseBalanceRepository
    .FromSqlRawSingleAsync($"MHSB.BankStatu @DepartmentId='{input.DepartmentId}', @TermId='{input.TermId}'");
            //
            var list = new List<FinancialStatusDto>
            {
                new FinancialStatusDto
                {
                    Description = L["Income"],
                    Price = safeStatu.Income
                },
                new FinancialStatusDto
                {
                    Description = L["Expense"],
                    Price = safeStatu.Expense
                },
                new FinancialStatusDto
                {
                    Description = L["Balance"],
                    Price = safeStatu.Balance
                }
            };
            //
            return list;
        }

        public virtual async Task<IList<FinancialStatusDto>> DistributionoPaymentDocumentListAsync(ReceiptDetailListParameterDto input)
        {
            var distribution = await _paymentDocumentsDistributionRepository
    .FromSqlRawAsync($"MHSB.PaymentDocumentsDistribution @DepartmentId='{input.DepartmentId}', @TermId='{input.TermId}'");
            //
            var list = new List<FinancialStatusDto>();
            //
            if(distribution.Count == 0)
            {
                distribution.Add(new PaymentDocumentsDistribution { PaymentType = PaymentType.Cheque, Amount = 0 });
                distribution.Add(new PaymentDocumentsDistribution { PaymentType = PaymentType.Bill, Amount = 0 });
                distribution.Add(new PaymentDocumentsDistribution { PaymentType = PaymentType.Cash, Amount = 0 });
                distribution.Add(new PaymentDocumentsDistribution { PaymentType = PaymentType.Bank, Amount = 0 });
                distribution.Add(new PaymentDocumentsDistribution { PaymentType = PaymentType.Pos, Amount = 0 });
            }
            //
            foreach(var item in distribution)
            {
                list.Add(new FinancialStatusDto
                {
                    Description = L[$"Enum:PaymentType:{(byte)item.PaymentType}"],
                    Price = item.Amount
                });
            }
            //
            return list;
        }

        public virtual async Task<IList<PaymentDocumentDto>> OverdueReceivablesListAsync(ReceiptDetailListParameterDto input)
        {
            var paymentTypes = $"{(byte)PaymentType.Cheque},{(byte)PaymentType.Bill},{(byte)PaymentType.Pos}";
            //
            var paymentDocuments = await _paymentDocumentRepository.FromSqlRawAsync($"MHSB.OverdueReceivables @DepartmentId='{input.DepartmentId}', @TermId='{input.TermId}',@PaymentTypes='{paymentTypes}',@Date='{DateTime.Now.Date:yyyy.MM.dd}'");
            //
            var list = new List<PaymentDocumentDto>();
            //
            if (paymentDocuments != null)
            {
                foreach (var item in paymentDocuments)
                {
                    list.Add(new PaymentDocumentDto
                    {
                        PaymentTypeName = L[$"Enum:PaymentType:{(byte)item.PaymentType}"],
                        ExpiryDate = item.ExpiryDate,
                        Price = item.Price,
                        Description = item.Description
                    });
                }
            }
            //
            return list;
        }
    }
}
