using MK.Accountancy.Invoices;
using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace MK.Accountancy.Stores
{
    public class ListStoreDto : EntityDto<Guid>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string SpecialCodeOneName { get; set; }
        public string SpecialCodeTwoName { get; set; }
        public string Description { get; set; }
        public decimal? AmountInput { get; set; }
        public decimal? OutputAmount { get; set; }
        public decimal? TheRemainingAmount => AmountInput - OutputAmount;
        public ICollection<SelectInvoiceDetailDto> InvoiceDetails { get; set; }
    }
}
