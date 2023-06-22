using MK.Accountancy.Companies;
using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace MK.Accountancy.Invoices
{
    public class InvoiceReportDto : IEntityDto
    {
        public string InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
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
        public string Description { get; set; }
        public SelectCompanyDto CompanyDto { get; set; }
        public List<InvoiceDetailReportDto> InvoiceDetails { get; set; }
    }
}
