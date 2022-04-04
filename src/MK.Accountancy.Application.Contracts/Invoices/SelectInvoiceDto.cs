using MK.Accountancy.CommonDtos;
using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace MK.Accountancy.Invoices
{
    public class SelectInvoiceDto : EntityDto<Guid>,ISpecialCode
    {
        public InvoiceType InvoiceType { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public Guid CurrentId { get; set; }
        public string CurrentName { get; set; }
        public string TaxOffice { get; set; }
        public string TaxNumber { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public decimal GrandTotal { get; set; }
        public decimal DiscountTotal { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal Netamount { get; set; }
        public int MovementNumber { get; set; }
        public Guid? SpecialCodeOneId { get; set; }
        public Guid? SpecialCodeTwoId { get; set; }
        public string SpecialCodeOneName { get; set; }
        public string SpecialCodeTwoName { get; set; }
        public Guid DepartmentId { get; set; }
        public Guid TermId { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public List<SelectInvoiceDetailDto> InvoiceDetails { get; set; }
    }
}
