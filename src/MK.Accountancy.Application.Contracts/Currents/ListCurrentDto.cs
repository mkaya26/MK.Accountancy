using MK.Accountancy.Invoices;
using MK.Accountancy.Receipts;
using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace MK.Accountancy.Currents
{
    public class ListCurrentDto : EntityDto<Guid>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string TaxDepartment { get; set; }
        public string TaxNumber { get; set; }
        public string Telephone { get; set; }
        public string Address { get; set; }
        public string SpecialCodeOneName { get; set; }
        public string SpecialCodeTwoName { get; set; }
        public decimal Debt { get; set; }
        public decimal Receivable { get; set; }
        public decimal DebtBalance => Debt - Receivable > 0 ? Debt - Receivable : 0;
        public decimal BalanceReceivable => Receivable - Debt > 0 ? Receivable - Debt : 0;
        public string Description { get; set; }
        public bool Active { get; set; }
        public ICollection<SelectInvoiceDto> Invoices { get; set; }
        public ICollection<SelectReceiptDto> Receipts { get; set; }

    }
}
